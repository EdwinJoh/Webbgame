using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedHelpers.DTO
{
    public record CharacterForCreationDto
    {
        public string CharacterName { get; set; }
        public int Level { get; set; } = 1;
        public List<Skills> Skills { get; set; } 
    }
}
