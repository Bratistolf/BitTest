using AutoMapper;
using Bit.WebApp.Models;
using Bit.WebApp.Models.Dtos;

namespace Bit.Api.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PlayerModel, PlayerCreateDto>();

            CreateMap<PlayerModel, PlayerEditDto>()
                .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.Id));

            CreateMap<PlayerViewDto, PlayerModel>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PlayerId));

            CreateMap<TeamModel, TeamCreateDto>();
        }
    }
}
