using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CharacterRepository : RepositoryBase<Characters>, ICharacterRepository
    {
        public CharacterRepository(RepositoryContext repo) : base(repo)
        {

        }

        public async Task<Characters> GetCharactersAsync(int id, bool trackChanges) =>
            await FindByCondition(x => x.Id == id, trackChanges).SingleOrDefaultAsync();

        public void CreateCharacter(Characters characters) => Create(characters);
        public void DeleteCharacter(Characters characters) => Delete(characters);
    }
}
