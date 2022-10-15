using Contracts;
using Entities.Models;
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
        public IEnumerable<Characters> GetAllCharacters(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.Name).ToList();
    }

}
