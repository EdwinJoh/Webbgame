using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class MissionNotFound : NotFoundException
    {
        public MissionNotFound(Guid id) : base($"The mission with id {id} does not exist ")
        {

        }
    }
}
