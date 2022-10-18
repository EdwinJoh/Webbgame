using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedHelpers.DTO
{
    public record CharacterDto(string CharacterName,int Level,List<Skills> skills);
    
}
