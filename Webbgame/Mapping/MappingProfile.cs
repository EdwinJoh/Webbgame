using AutoMapper;
using Entities.Models;
using SharedHelpers.DTO.CharacterDtos;
using SharedHelpers.DTO.CharacterDtos.Weapons;
using SharedHelpers.DTO.MissionDtos;
using SharedHelpers.DTO.SkillsDtos;

namespace Webbgame.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Characters, CharacterDto>();
            CreateMap<CharacterDto, Characters>();
            CreateMap<CharacterForCreationDto, Characters>();
            CreateMap<CharacterFotUpdateDto, CharacterDto>().ReverseMap();
            CreateMap<CharacterFotUpdateDto, Characters>();

            CreateMap<Mission, MissionDto>();
            CreateMap<MissionDto, Mission>();
            CreateMap<MissionForCreateDto, Mission>();

            CreateMap<WeaponDto, Weapon>();
            CreateMap<Weapon, WeaponDto>();
            CreateMap<WeaponForCreation,Weapon>();

            CreateMap<Skills, SkillDto>();
            CreateMap<SkillDto, Skills>();

        }
    }
}
