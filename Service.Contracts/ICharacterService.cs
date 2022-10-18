﻿using SharedHelpers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICharacterService
    {
        Task<CharacterDto> GetCharacterAsync(int id,bool trackChanges);
        Task<CharacterDto> CreateCharacterAsync(CharacterForCreationDto character);
    }
}
