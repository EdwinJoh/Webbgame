using AutoMapper;
using Contracts;
using Service.Contracts;
using Entities.Models;
using System.Net.Http.Headers;
using Repository;
using Microsoft.EntityFrameworkCore;
using SharedHelpers.DTO.MissionDtos;
using Entities.Exceptions;
using SharedHelpers.DTO.CharacterDtos;

namespace Service
{
    public class CharacterService : ICharacterService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly RepositoryContext _repositoryContext;

        public CharacterService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, RepositoryContext context)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _repositoryContext = context;
        }
        public async Task<CharacterDto> GetCharacterAsync(string email, bool trackChanges)
        {
            var character = await _repository.Character.GetCharactersAsync(email, trackChanges);
            character.Skills = await _repository.Skill.GetSkill(character.Id, trackChanges: false) ;
            var characterDto = _mapper.Map<CharacterDto>(character);

            return characterDto;
        }

        public async Task<CharacterDto> CreateCharacterAsync(CharacterForCreationDto character)
        {
            var characterEntity = _mapper.Map<Characters>(character);
            characterEntity.Skills = CreateSkillForCharacter(characterEntity.Id);

            _repository.Character.CreateCharacter(characterEntity);
            await _repository.SaveAsync();

            var characterToReturn = _mapper.Map<CharacterDto>(characterEntity);

            return characterToReturn;
        }
        private Skills CreateSkillForCharacter(Guid characterId)
        {
            Skills newSkill = new();
            newSkill.CharacterId = characterId;
            newSkill.RobberyLV = 1;

            return newSkill;
        }
        
       public async Task UpdateCharacter(Guid id,CharacterFotUpdateDto character,bool trackChanges)
        {
            await CheckIfCharacterExist(character.UserEmail, id, trackChanges);

            var characterDb = await _repository.Character.GetCharactersAsync(character.UserEmail, trackChanges);

            _mapper.Map(character, characterDb);
            await _repository.SaveAsync();

        }
        private async Task CheckIfCharacterExist(string email,Guid id, bool trackChanges)
        {
            var character = await _repository.Character.GetCharactersAsync(email,trackChanges);
            if (character == null)
                throw new CharacterNotFoundException(id);
        }
       
    }
}
