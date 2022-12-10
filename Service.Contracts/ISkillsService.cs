using SharedHelpers.DTO.SkillsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts;

public interface ISkillsService
{
    Task<List<SkillDto>> GetSkills(bool trackChanges);
    Task<SkillDto> GetSkillsById(int id,bool trackChanges);
}
