using AutoMapper;
using Contracts;
using Microsoft.Extensions.Configuration;
using Repository;
using Service.Contracts;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<ICharacterService> _characterService;
    private readonly Lazy<IMissionService> _missionService;
    private readonly Lazy<IAuthenticationService> _authenticationService;
    private readonly Lazy<IWeaponService> _weaponService;

    public readonly IMapper _mapper;
    public readonly RepositoryContext repositoryContext;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
    logger, IMapper mapper, IConfiguration configuration)
    {

        _characterService = new Lazy<ICharacterService>(() => new
        CharacterService(repositoryManager, logger, mapper, repositoryContext));

        _missionService = new Lazy<IMissionService>(() => new
        MissionService(repositoryManager, logger, mapper));

        _authenticationService = new Lazy<IAuthenticationService>(() =>
        new AuthenService(repositoryContext, configuration));

        _weaponService = new Lazy<IWeaponService>(() =>
        new WeaponSevice(repositoryManager,logger,mapper));
    }
    public ICharacterService CharacterService => _characterService.Value;
    public IMissionService MissionService => _missionService.Value;
    public IAuthenticationService AuthenticationService => _authenticationService.Value;


}
