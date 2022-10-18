using AutoMapper;
using Contracts;
using Service.Contracts;
using SharedHelpers.DTO;
using Entities.Models;
using System.Net.Http.Headers;

namespace Service
{
    public class CharacterService : ICharacterService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CharacterService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<CharacterDto> GetCharacterAsync(int id, bool trackChanges)
        {
            var character = await _repository.Character.GetCharactersAsync(id, trackChanges);
            var characterDto = _mapper.Map<CharacterDto>(character);

            return characterDto;
        }

        public async Task<CharacterDto> CreateCharacterAsync(CharacterForCreationDto character)
        {
            var characterEntity = _mapper.Map<Characters>(character);

             _repository.Character.CreateCharacter(characterEntity);
            await _repository.SaveAsync();

            var characterToReturn = _mapper.Map<CharacterDto>(characterEntity);

            return characterToReturn;
        }

    }
}
