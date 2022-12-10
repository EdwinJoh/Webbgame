namespace Entities.Exceptions;

public sealed class CharacterNotFoundException : NotFoundException
{
    public CharacterNotFoundException(int characterId) : base($"The character with id: {characterId} does not exist in the database.")
    {

    }
}
