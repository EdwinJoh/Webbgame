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
        public readonly IMapper _mapper;
        public readonly RepositoryContext repositoryContext;
        private readonly Lazy<IAuthService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
        logger, IMapper mapper, IConfiguration configuration)
        {
       
            _characterService = new Lazy<ICharacterService>(() => new
            CharacterService(repositoryManager, logger, mapper,repositoryContext));

            _authenticationService = new Lazy<IAuthService>(() =>
            new AuthenService(repositoryContext, configuration));
        }
        public ICharacterService CharacterService => _characterService.Value;
        public IAuthService AuthenticationService => _authenticationService.Value;


    }
}
