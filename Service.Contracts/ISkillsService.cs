using SharedHelpers.DTO.SkillsDtos;

namespace Service.Contracts;

public interface ISkillsService
{
    Task<List<SkillDto>> GetSkills(bool trackChanges);
    Task<SkillDto> GetSkillsById(int id, bool trackChanges);
}