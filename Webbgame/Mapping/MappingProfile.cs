using AutoMapper;
using Entities.Models;
using SharedHelpers.DTO;
using SharedHelpers.DTO.MissionDtos;

namespace Webbgame.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Characters, CharacterDto>();
            CreateMap<CharacterDto, Characters>();
            CreateMap<CharacterForCreationDto, Characters>();
            CreateMap<Mission, MissionDto>();
            CreateMap< MissionDto,Mission>();
        }
    }
}
