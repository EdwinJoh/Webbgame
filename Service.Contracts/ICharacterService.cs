using SharedHelpers.DTO.CharacterDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICharacterService
    {
        Task<CharacterDto> GetCharacterAsync(string email, bool trackChanges);
        Task<CharacterDto> CreateCharacterAsync(CharacterForCreationDto character);
        Task UpdateCharacter(Guid id, CharacterFotUpdateDto character, bool trackChanges);
    }
}
