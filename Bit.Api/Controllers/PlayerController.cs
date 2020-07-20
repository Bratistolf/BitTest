using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Bit.Api.Domain.Entities;
using Bit.Api.Domain.Models;
using Bit.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IRepository<Player> _repository;
        private readonly IMapper _mapper;

        public PlayerController(IRepository<Player> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var players = await _repository.GetAllAsync();
            var playersDto = _mapper.Map<IEnumerable<PlayerViewDto>>(players);

            return Ok(playersDto);
        }

        [HttpGet("{id}", Name = "GetPlayer")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var player = await _repository.GetAsync(id);

            var playerDto = _mapper.Map<PlayerViewDto>(player);

            return Ok(playerDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PlayerCreateDto playerCreateDto)
        {
            var player = _mapper.Map<Player>(playerCreateDto);
            _repository.Create(player);
            var isSuccess = await _repository.SaveChangesAsync();
            if (!isSuccess)
            {
                return BadRequest();
            }

            var playerViewDto = _mapper.Map<PlayerViewDto>(player);

            return CreatedAtRoute("GetPlayer", new { id = playerViewDto.PlayerId }, playerViewDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PlayerUpdateDto playerUpdateDto)
        {
            var player = await _repository.GetAsync(id);

            _mapper.Map(playerUpdateDto, player);
            _repository.Update(player);
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
