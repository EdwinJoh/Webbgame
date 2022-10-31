namespace Contracts;

public interface IRepositoryManager
{
    ICharacterRepository Character { get; }
    IMissionRepository Mission { get; }
    ISkillRepository Skill { get; }
    Task SaveAsync();
}
