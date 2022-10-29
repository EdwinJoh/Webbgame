using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MissionRepository :RepositoryBase<Mission>, IMissionRepository
    {
        public MissionRepository(RepositoryContext repo) :base(repo)
        {

        }

        public async Task<Mission> GetMission(Guid id,bool trackChanges) =>
           await FindByCondition(x => x.Id.Equals(id),trackChanges).FirstOrDefaultAsync();


        public async Task<IEnumerable<Mission>> GetMissions(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public void CreateMission(Mission mission) => Create(mission);
        public void DeleteMission(Mission mission) => Delete(mission);

        public async Task<Mission> GetMissionByName(string name,bool trackChanges) =>
            await FindByCondition(x => x.Name.Equals(name),trackChanges).FirstOrDefaultAsync();
    }
}
