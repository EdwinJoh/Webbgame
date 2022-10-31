using SharedHelpers.DTO.CharacterDtos;
using SharedHelpers.DTO.MissionDtos;

namespace Webbgame.UI.Services
{
    public interface IRequestService
    {
        Task<CharacterDto> GetCharacter(string email);
        Task<CharacterDto> CreateCharacter(CharacterForCreationDto character);
        Task<MissionDto> CreateMission(MissionForCreateDto mission);
        Task<IEnumerable<MissionDto>> GetMissions();
        Task UpdateCharacter( CharacterDto character);
    }

}