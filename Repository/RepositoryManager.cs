using Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<ICharacterRepository> _characterRepository;
    private readonly Lazy<IMissionRepository> _missionRepository;
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<ISkillRepository> _skillRepository;
    private readonly Lazy<IWeaponRepository> _weaponRepository;


    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _characterRepository = new Lazy<ICharacterRepository>(() => new
            CharacterRepository(repositoryContext));

        _missionRepository = new Lazy<IMissionRepository>(() =>
            new MissionRepository(repositoryContext));

        _skillRepository = new Lazy<ISkillRepository>(() =>
            new SkillRepository(repositoryContext));

        _weaponRepository = new Lazy<IWeaponRepository>(() =>
            new WeaponRepository(repositoryContext));
    }

    public ICharacterRepository Character => _characterRepository.Value;
    public IMissionRepository Mission => _missionRepository.Value;
    public ISkillRepository Skill => _skillRepository.Value;
    public IWeaponRepository Weapon => _weaponRepository.Value;

    public async Task SaveAsync()
    {
        await _repositoryContext.SaveChangesAsync();
    }
}