using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class CharacterRepository : RepositoryBase<Characters>, ICharacterRepository
    {
        public CharacterRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Characters>> GetAllCharactersAsync(bool trackChanges) =>
           await FindAll(trackChanges)
            .OrderBy(c => c.Name).ToListAsync();
    }

}
