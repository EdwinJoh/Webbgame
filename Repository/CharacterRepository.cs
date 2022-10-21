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

        public async Task<Characters> GetCharactersAsync(string email, bool trackChanges) =>
            await FindByCondition(x => x.UserEmail == email, trackChanges).SingleOrDefaultAsync();

        public void CreateCharacter(Characters characters) => Create(characters);
        public void DeleteCharacter(Characters characters) => Delete(characters);
    }
}
