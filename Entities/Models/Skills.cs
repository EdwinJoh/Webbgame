using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Skills
    {
        public Guid Id { get; set; }
        public Guid CharacterId { get; set; }
        public int RobberyLV { get; set; }
    }
}
