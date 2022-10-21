using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedHelpers.DTO
{
    public record CharacterDto(Guid Id,string CharacterName,int Level,Skills? Skills);
    
}
