using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

internal sealed class MissionRepository : RepositoryBase<Mission>, IMissionRepository
{
    public MissionRepository(RepositoryContext repo) : base(repo)
    {
    }

    public async Task<Mission> GetMission(int id, bool trackChanges)
    {
        return await FindByCondition(x => x.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
    }


    public async Task<IEnumerable<Mission>> GetMissions(bool trackChanges)
    {
        return await FindAll(trackChanges).ToListAsync();
    }

    public void CreateMission(Mission mission)
    {
        Create(mission);
    }

    public void DeleteMission(Mission mission)
    {
        Delete(mission);
    }

    public async Task<Mission> GetMissionByName(string name, bool trackChanges)
    {
        return await FindByCondition(x => x.Name.Equals(name), trackChanges).FirstOrDefaultAsync();
    }
}