using AutoMapper;
using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICharacterService> _characterService;
        public readonly IMapper _mapper;
        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
        logger, IMapper mapper)
        {
            _characterService = new Lazy<ICharacterService>(() => new
            CharacterService(repositoryManager, logger, mapper));

        }
        public ICharacterService CharacterService => _characterService.Value;

    }
}
