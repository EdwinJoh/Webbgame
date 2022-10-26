using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMissionRepository
    {
        Task<Mission> GetMission(Guid id,bool trackChanges);
        Task<IEnumerable<Mission>> GetMissions(bool trackChanges);
    }
}
