using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedHelpers.DTO
{
    public record CharacterForCreationDto
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        [Required]
        public string CharacterName { get; set; }
        public int Level { get; set; } = 1;
        public Skills? Skills { get; set; }
    }
}
