using AutoMapper;
using Entities.Models;
using SharedHelpers.DTO;

namespace Webbgame.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Characters, CharacterDto>();
            CreateMap<CharacterDto, Characters>();
            CreateMap<CharacterForCreationDto, Characters>();
        }
    }
}
