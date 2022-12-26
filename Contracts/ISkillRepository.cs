using Entities.Models;

namespace Contracts;

public interface ISkillRepository
{
    Task<Skills> GetSkillById(int id, bool trackChanges);
    Task<List<Skills>> GetSkills(bool trackCHanges);
    void CreateSkill(Skills skill);
}