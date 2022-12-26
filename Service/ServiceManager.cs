using AutoMapper;
using Contracts;
using Microsoft.Extensions.Configuration;
using Repository;
using Service.Contracts;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IAuthService> _authenticationService;
    private readonly Lazy<ICharacterService> _characterService;

    public readonly IMapper _mapper;
    private readonly Lazy<IMissionService> _missionService;
    private readonly Lazy<ISkillsService> _skillService;
    private readonly Lazy<IWeaponService> _weaponService;
    public readonly RepositoryContext repositoryContext;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
        logger, IMapper mapper, IConfiguration configuration)
    {
        _characterService = new Lazy<ICharacterService>(() => new
            CharacterService(repositoryManager, logger, mapper, repositoryContext));

        _missionService = new Lazy<IMissionService>(() => new
            MissionService(repositoryManager, logger, mapper));

        _authenticationService = new Lazy<IAuthService>(() =>
            new AuthService(repositoryContext, configuration));

        _weaponService = new Lazy<IWeaponService>(() =>
            new WeaponSevice(repositoryManager, logger, mapper));

        _skillService = new Lazy<ISkillsService>(() =>
            new SkillsService(repositoryManager, logger, mapper));
    }

    public ICharacterService CharacterService => _characterService.Value;
    public IMissionService MissionService => _missionService.Value;
    public IAuthService AuthenticationService => _authenticationService.Value;
    public IWeaponService WeaponService => _weaponService.Value;
    public ISkillsService SkillService => _skillService.Value;
}