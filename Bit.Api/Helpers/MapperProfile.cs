using AutoMapper;
using Bit.Api.Domain.Entities;
using Bit.Api.Domain.Models;
using Bit.Api.Domain.Models.Team;
using Bit.Api.Services.Interfaces;

namespace Bit.Api.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Player, PlayerViewDto>();
            CreateMap<PlayerUpdateDto, Player>();
            CreateMap<PlayerCreateDto, Player>();

            CreateMap<Team, TeamViewDto>();
            CreateMap<TeamUpdateDto, Team>();
            CreateMap<TeamCreateDto, Team>();
        }
    }
}
