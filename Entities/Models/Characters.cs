using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Characters
    {
        public int Id { get; set; }
        public string CharacterName { get; set; }
        public int Level { get; set; }
        public List<Skills> Skills { get; set; }
    }
}
