namespace Contracts;

public interface IRepositoryManager
{
    ICharacterRepository Character { get; }
    IMissionRepository Mission { get; }
    Task SaveAsync();
}
