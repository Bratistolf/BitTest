using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Bit.Api.Domain.Entities;
using Bit.Api.Domain.Models;
using Bit.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bit.Api.Domain.Models.Team;

namespace Bit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly IRepository<Team> _repository;
        private readonly IMapper _mapper;

        public TeamController(IRepository<Team> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _repository.GetAllAsync();
            var teamsDto = _mapper.Map<IEnumerable<TeamViewDto>>(teams);

            return Ok(teamsDto);
        }

        [HttpGet("{id}", Name = "GetTeam")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var team = await _repository.GetAsync(id);

            var teamDto = _mapper.Map<TeamViewDto>(team);

            return Ok(teamDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeamCreateDto teamCreateDto)
        {
            var team = _mapper.Map<Team>(teamCreateDto);
            _repository.Create(team);
            var isSuccess = await _repository.SaveChangesAsync();
            if (!isSuccess)
            {
                return BadRequest();
            }

            var teamViewDto = _mapper.Map<TeamViewDto>(team);

            return CreatedAtRoute("GetTeam", new { id = teamViewDto.TeamId }, teamViewDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TeamUpdateDto teamUpdateDto)
        {
            var team = await _repository.GetAsync(id);

            _mapper.Map(teamUpdateDto, team);
            _repository.Update(team);
            var isSuccess = await _repository.SaveChangesAsync();
            if (!isSuccess)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var player = await _repository.GetAsync(id);

            _repository.Delete(player);
            var isSuccess = await _repository.SaveChangesAsync();

            if (!isSuccess)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
