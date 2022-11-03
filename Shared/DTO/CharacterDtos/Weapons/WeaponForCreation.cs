using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedHelpers.DTO.CharacterDtos.Weapons
{
    public record WeaponForCreation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
