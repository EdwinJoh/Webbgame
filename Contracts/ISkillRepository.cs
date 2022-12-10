using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISkillRepository
    {
        Task<Skills> GetSkillById(int id,bool trackChanges);
        Task<List<Skills>> GetSkills(bool trackCHanges);
        void CreateSkill(Skills skill);
    }
}
