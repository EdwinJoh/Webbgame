using SharedHelpers.DTO.CharacterDtos;
using SharedHelpers.DTO.MissionDtos;

namespace Service.Contracts;

public interface IMissionService
{
    Task<MissionDto> GetMissionAsync(int guid, bool trackChanges);
    Task<IEnumerable<MissionDto>> GetMissionsAsync(bool trackChanges);
    Task<MissionDto> CreateMissionAsync(MissionForCreateDto mission, bool trackChanges);
    Task<MissionDto> GetMissionByName(string name, bool trackChanges);

}