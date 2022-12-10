using Entities.Models;

namespace Contracts;

public interface ICharacterRepository
{
    void CreateCharacter(Characters characters);
    void DeleteCharacter(Characters characters);
    void UpdateCharacter(Characters characters);

    Task<List<Characters>> GetCharactersAsync(bool trackChanges);
    Task<Characters> GetCharacterById(int id, bool trackChanges);
}