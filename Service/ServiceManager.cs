using AutoMapper;
using Contracts;
using Microsoft.Extensions.Configuration;
using Repository;
using Service.Contracts;

namespace Service;

public  class ServiceManager : IServiceManager
{
    private readonly Lazy<ICharacterService> _characterService;
    private readonly Lazy<IMissionService> _missionService;
    private readonly Lazy<Contracts.IAuthService> _authenticationService;
    private readonly Lazy<IWeaponService> _weaponService;
    private readonly Lazy<ISkillsService> _skillService;

    public readonly IMapper _mapper;
    public readonly RepositoryContext repositoryContext;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
    logger, IMapper mapper, IConfiguration configuration)
    {

        _characterService = new Lazy<ICharacterService>(() => new
        CharacterService(repositoryManager, logger, mapper, repositoryContext));

        _missionService = new Lazy<IMissionService>(() => new
        MissionService(repositoryManager, logger, mapper));

        _authenticationService = new Lazy<Contracts.IAuthService>(() =>
        new AuthService(repositoryContext, configuration));

        _weaponService = new Lazy<IWeaponService>(() =>
        new WeaponSevice(repositoryManager,logger,mapper)); 
        
        _skillService = new Lazy<ISkillsService>(() =>
        new SkillsService(repositoryManager, logger, mapper));
    }
    public ICharacterService CharacterService => _characterService.Value;
    public IMissionService MissionService => _missionService.Value;
    public Contracts.IAuthService AuthenticationService => _authenticationService.Value;
    public IWeaponService WeaponService => _weaponService.Value;
    public ISkillsService SkillService => _skillService.Value;


}
