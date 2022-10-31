namespace Entities.Exceptions;

public sealed class CharacterNotFoundException : NotFoundException
{
    public CharacterNotFoundException(Guid characterId) : base($"The character with id: {characterId} does not exist in the database.")
    {

    }
}
