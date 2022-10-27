using SharedHelpers.DTO.MissionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IMissionService
    {
        Task<MissionDto> GetMissionAsync(Guid guid, bool trackChanges);
        Task<IEnumerable<MissionDto>> GetMissionsAsync( bool trackChanges);
    }
}
