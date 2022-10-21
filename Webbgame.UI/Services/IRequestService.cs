using SharedHelpers.DTO;

namespace Webbgame.UI.Services
{
    public interface IRequestService
    {
        Task<CharacterDto> GetCharacter(string email);
        Task<CharacterDto> CreateCharacter(CharacterForCreationDto character);
    }
}