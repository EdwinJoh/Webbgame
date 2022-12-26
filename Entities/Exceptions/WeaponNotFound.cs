namespace Entities.Exceptions;

public sealed class WeaponNotFound : NotFoundException
{
    public WeaponNotFound(string id) : base($"The weapon with name: {id} does not exist")
    {
    }
}