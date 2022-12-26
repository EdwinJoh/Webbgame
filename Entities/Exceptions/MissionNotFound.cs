namespace Entities.Exceptions;

public sealed class MissionNotFound : NotFoundException
{
    public MissionNotFound(Guid id) : base($"The mission with id {id} does not exist ")
    {
    }
}