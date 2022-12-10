using Entities.Models;

namespace Contracts;

public interface IMissionRepository
{
    Task<Mission> GetMission(int id, bool trackChanges);
    Task<IEnumerable<Mission>> GetMissions(bool trackChanges);
    void CreateMission(Mission mission);
    void DeleteMission(Mission mission);
    Task<Mission> GetMissionByName(string name, bool trackChanges);
}
