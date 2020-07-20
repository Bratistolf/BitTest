using AutoMapper;
using Bit.WebApp.Models;
using Bit.WebApp.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bit.WebApp.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IMapper _mapper;

        public PlayerController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var playersUrl = "https://localhost:5001/player/";

            var playerResponce = await client.GetAsync(playersUrl);
            var playerContent = await playerResponce.Content.ReadAsStringAsync();
            var playerDtos = JsonConvert.DeserializeObject<List<PlayerViewDto>>(playerContent);
            var playerModels = _mapper.Map<List<PlayerModel>>(playerDtos);


            var teamModels = await GetTeams();

            var playerListModel = new PlayerListViewModel
            {
                Players = playerModels,
                Teams = teamModels
            };

            return View("Index", playerListModel);
        }

        public async Task<IActionResult> CreateEdit(int? id)
        {
            var playerEditCreateModel = new PlayerCreateEditViewModel
            {
                Player = new PlayerModel()
            };

            if (id.HasValue && id.Value != 0)
            {
                var client = new HttpClient();
                var url = $"https://localhost:5001/player/{id}";

                var responce = await client.GetAsync(url);
                if (responce.IsSuccessStatusCode)
                {
                    var content = await responce.Content.ReadAsStringAsync();
                    var dto = JsonConvert.DeserializeObject<PlayerViewDto>(content);
                    playerEditCreateModel.Player = _mapper.Map<PlayerModel>(dto);
                }
            }
            playerEditCreateModel.Teams = await GetTeams();
            return View("CreateEdit", playerEditCreateModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEdit(int? id, PlayerCreateEditViewModel playerCreateEditModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id.HasValue)
                    {
                        var result = await Edit(id.Value, playerCreateEditModel);
                        return result;
                    }
                    else
                    {
                        var result = await Create(playerCreateEditModel);
                        return result;
                    }
                }
                return View("CreateEdit", playerCreateEditModel);
            }
            catch
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = new HttpClient();
            var url = $"https://localhost:5001/player/{id}";

            var responce = await client.DeleteAsync(url);

            return RedirectToAction(nameof(Index));
        }

        private async Task<IActionResult> Edit(int id, PlayerCreateEditViewModel playerEditModel)
        {
            var playerToEdit = playerEditModel.Player;

            if (playerEditModel.IsNewTeam)
            {
                var newTeamName = playerEditModel.NewTeamName;
                var newTeamId = await CreateTeam(newTeamName);
                playerToEdit.TeamId = newTeamId;
            }

            var client = new HttpClient();
            var url = $"https://localhost:5001/player/{id}";

            var dto = _mapper.Map<PlayerEditDto>(playerToEdit);
            var json = JsonConvert.SerializeObject(dto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var responce = await client.PutAsync(url, data);

            if (responce.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("Error");
        }

        private async Task<IActionResult> Create(PlayerCreateEditViewModel playerCreateModel)
        {
            var playerToCreate = playerCreateModel.Player;

            if (playerCreateModel.IsNewTeam)
            {
                var newTeamName = playerCreateModel.NewTeamName;
                var newTeamId = await CreateTeam(newTeamName);
                playerToCreate.TeamId = newTeamId;
            }

            var client = new HttpClient();
            var url = $"https://localhost:5001/player/";

            var dto = _mapper.Map<PlayerCreateDto>(playerToCreate);
            var json = JsonConvert.SerializeObject(dto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var responce = await client.PostAsync(url, data);

            if (responce.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("Error");
        }

        private async Task<IEnumerable<TeamModel>> GetTeams()
        {
            var client = new HttpClient();
            var teamsUrl = "https://localhost:5001/team/";

            var teamsResponce = await client.GetAsync(teamsUrl);
            var teamsContent = await teamsResponce.Content.ReadAsStringAsync();
            var teamsModels = JsonConvert.DeserializeObject<List<TeamModel>>(teamsContent);

            return teamsModels;
        }

        private async Task<int> CreateTeam(string name)
        {
            var teamCreateDto = new TeamCreateDto
            {
                TeamName = name
            };
            var client = new HttpClient();
            var url = $"https://localhost:5001/team/";

            var json = JsonConvert.SerializeObject(teamCreateDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var responce = await client.PostAsync(url, data);
            var content = await responce.Content.ReadAsStringAsync();
            var teamModel = JsonConvert.DeserializeObject<TeamModel>(content);

            return teamModel.TeamId;
        }
    }
}