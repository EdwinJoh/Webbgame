using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CharacterNotFoundException :NotFoundException
    {
        public CharacterNotFoundException(Guid characterId) :base($"The character with id: {characterId} does not exist in the database.")
        {

        }
    }
}
