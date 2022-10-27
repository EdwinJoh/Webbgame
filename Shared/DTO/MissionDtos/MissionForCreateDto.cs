using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedHelpers.DTO.MissionDtos
{
    public class MissionForCreateDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Money { get; set; }
    }
}
