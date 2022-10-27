using AutoMapper;
using Contracts;
using Microsoft.Extensions.Configuration;
using Repository;
using Service.Contracts;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICharacterService> _characterService;
        private readonly Lazy<IMissionService> _missionService;
        public readonly IMapper _mapper;
        public readonly RepositoryContext repositoryContext;
        private readonly Lazy<IAuthService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
        logger, IMapper mapper, IConfiguration configuration)
        {
       
            _characterService = new Lazy<ICharacterService>(() => new
            CharacterService(repositoryManager, logger, mapper,repositoryContext));
            
            _missionService = new Lazy<IMissionService>(() => new
            MissionService(repositoryManager, logger, mapper));

            _authenticationService = new Lazy<IAuthService>(() =>
            new AuthenService(repositoryContext, configuration));
        }
        public ICharacterService CharacterService => _characterService.Value;
        public IMissionService MissionService => _missionService.Value;
        public IAuthService AuthenticationService => _authenticationService.Value;


    }
}
