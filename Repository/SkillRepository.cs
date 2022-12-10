using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

internal sealed class SkillRepository : RepositoryBase<Skills>, ISkillRepository
{
    public SkillRepository(RepositoryContext repo) : base(repo)
    {

    }
   

    public async Task<Skills> GetSkillById(int id, bool trackChanges) =>
       await FindByCondition(x => x.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

    public async Task<List<Skills>> GetSkills(bool trackChanges) =>
        await FindAll(trackChanges).ToListAsync();
    public void CreateSkill(Skills skill) => Create(skill);

}
