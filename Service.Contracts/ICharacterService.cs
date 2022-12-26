using SharedHelpers.DTO.CharacterDtos;

namespace Service.Contracts;

public interface ICharacterService
{
    Task<List<CharacterDto>> GetCharacters(bool trackChanges);
    Task<CharacterDto> GetCharacter(int id, bool trackChanges);
    Task<CharacterDto> CreateCharacter(CharacterForCreationDto character);
}