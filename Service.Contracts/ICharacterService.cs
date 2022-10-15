using Entities.Models;
using SharedHelpers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICharacterService
    {
       Task< IEnumerable<CharacterDto>> GetAllCharactersAsync(bool trackChanges);
    }
}
