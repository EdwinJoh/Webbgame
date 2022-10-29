using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Identity.Client;
using Service.Contracts;
using SharedHelpers.DTO.MissionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MissionService : IMissionService
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
        public async Task<MissionDto> GetMissionAsync(Guid guid, bool trackChanges)
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
            mission.Id = Guid.NewGuid();
            var missionEntity = _mapper.Map<Mission>(mission);

            _repository.Mission.CreateMission(missionEntity);
            await _repository.SaveAsync();

            var missionToReturn = _mapper.Map<MissionDto>(missionEntity);
            return missionToReturn;
        }

        private async Task CheckIfMissionExist(Guid id)
        {
            var mission = await _repository.Mission.GetMission(id, trackChanges: false);
            if (mission == null)
                throw new Exception($"Did not found mission with ID: {id} ");
        }

        public async Task<MissionDto> GetMissionByName(string name, bool trackChanges)
        {
            CheckIfMissionExist(name);
            var missionEntity = await _repository.Mission.GetMissionByName(name, trackChanges);

            var missionDto = _mapper.Map<MissionDto>(missionEntity);

            return missionDto;

        }

        private bool CheckIfMissionExist(string name)
        {
            var mission = _repository.Mission.GetMissionByName(name, trackChanges: false);
            if (mission == null)
                throw new Exception();
            return true;
        }
    }
}
