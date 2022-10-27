using SharedHelpers.DTO;
using SharedHelpers.DTO.MissionDtos;

namespace Webbgame.UI.Services
{
    public interface IRequestService
    {
        Task<CharacterDto> GetCharacter(string email);
        Task<CharacterDto> CreateCharacter(CharacterForCreationDto character);
        Task<MissionDto> CreateMission(MissionForCreateDto mission);
    }
}