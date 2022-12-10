using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

internal sealed class CharacterRepository : RepositoryBase<Characters>, ICharacterRepository
{
    public CharacterRepository(RepositoryContext repo) : base(repo)
    {

    }



    public void CreateCharacter(Characters characters) => Create(characters);
    public void DeleteCharacter(Characters characters) => Delete(characters);
    public void UpdateCharacter(Characters characters) => Update(characters);

    public async Task<List<Characters>> GetCharactersAsync(bool trackChanges) =>
       await FindAll(trackChanges).OrderBy(x => x.Id).ToListAsync();

    public async Task<Characters> GetCharacterById(int id, bool trackChanges) =>
     await FindByCondition(x => x.Id.Equals(id), trackChanges)!.SingleOrDefaultAsync();
}
