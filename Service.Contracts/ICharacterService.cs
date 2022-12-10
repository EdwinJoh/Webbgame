using SharedHelpers.DTO.CharacterDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts;

public interface ICharacterService
{
    Task<List<CharacterDto>> GetCharacters(bool trackChanges);
    Task<CharacterDto> GetCharacter(int id,bool trackChanges);
    Task<CharacterDto> CreateCharacter(CharacterForCreationDto character);
}
