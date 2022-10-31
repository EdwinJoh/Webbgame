using SharedHelpers.DTO;

namespace Service.Contracts;

public interface ICharacterService
{
    Task<CharacterDto> GetCharacterAsync(string email, bool trackChanges);
    Task<CharacterDto> CreateCharacterAsync(CharacterForCreationDto character);
}
