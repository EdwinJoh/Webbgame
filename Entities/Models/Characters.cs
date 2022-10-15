﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Characters
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public ICollection<Skills>? Skills { get; set; }
    }
}
