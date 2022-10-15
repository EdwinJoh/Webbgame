using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class CharacterService : ICharacterService
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
        public async Task< IEnumerable<CharacterDto>> GetAllCharactersAsync(bool trackChanges)
        {
            var characters = await _repository.Character.GetAllCharactersAsync(trackChanges);

            var characterDto = _mapper.Map<IEnumerable<CharacterDto>>(characters);

            return characterDto;

        }


    }
}
