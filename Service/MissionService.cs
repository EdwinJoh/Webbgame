using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using SharedHelpers.DTO.MissionDtos;

namespace Service;

internal sealed class MissionService : IMissionService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public MissionService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _repository = repositoryManager;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<MissionDto> GetMissionAsync(int guid, bool trackChanges)
    {
        await CheckIfMissionExist(guid);
        var mission = await _repository.Mission.GetMission(guid, trackChanges);
        var missionDto = _mapper.Map<MissionDto>(mission);

        return missionDto;
    }

    public async Task<IEnumerable<MissionDto>> GetMissionsAsync(bool trackChanges)
    {
        var missions = await _repository.Mission.GetMissions(trackChanges);

        var missionsDto = _mapper.Map<IEnumerable<MissionDto>>(missions);

        return missionsDto;
    }

    public async Task<MissionDto> CreateMissionAsync(MissionForCreateDto mission, bool trackChanges)
    {
        
        mission.Name = mission.Name.ToLower();
        var missionEntity = _mapper.Map<Mission>(mission);

        _repository.Mission.CreateMission(missionEntity);
        await _repository.SaveAsync();

        var missionToReturn = _mapper.Map<MissionDto>(missionEntity);
        return missionToReturn;
    }

    private async Task CheckIfMissionExist(int id)
    {
        var mission = await _repository.Mission.GetMission(id, trackChanges: false);
        if (mission == null) {return; }
            //throw new MissionNotFound(mission.Id);
    }

    public async Task<MissionDto> GetMissionByName(string name, bool trackChanges)
    {
        await CheckIfMissionExistByName(name);
        var missionEntity = await _repository.Mission.GetMissionByName(name, trackChanges);

        var missionDto = _mapper.Map<MissionDto>(missionEntity);

        return missionDto;

    }

    private async Task<bool> CheckIfMissionExistByName(string name)
    {
        var mission = await _repository.Mission.GetMissionByName(name, trackChanges: false);

        if (mission == null)
            return false;
            //throw new MissionNotFound(mission.Id);
        return true;
    }
}
