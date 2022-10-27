using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Mission
    {
        public Guid Id { get; set; }
        public string  Name { get; set; }
        public int  Money { get; set; }
    }
}
