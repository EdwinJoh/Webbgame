﻿using Entities.Models;

namespace Contracts
{
    public interface ICharacterRepository
    {
        void CreateCharacter(Characters characters);
        void DeleteCharacter(Characters characters);
        Task<Characters> GetCharactersAsync(string email, bool trackChanges);
    }
}