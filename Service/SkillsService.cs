using AutoMapper;
using Contracts;
using Repository;
using Service.Contracts;
using SharedHelpers.DTO.SkillsDtos;

namespace Service;

public class SkillsService : ISkillsService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;
    private readonly RepositoryContext _repositoryContext;

    public SkillsService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<List<SkillDto>> GetSkills(bool trackChanges)
    {
        var skills = await _repository.Skill.GetSkills(trackChanges);

        var skillsdtos = _mapper.Map<List<SkillDto>>(skills);

        return skillsdtos;
    }

    public async Task<SkillDto> GetSkillsById(int id, bool trackChanges)
    {
        var skill = await _repository.Skill.GetSkillById(id, trackChanges);

        if (skill == null)
            throw new Exception();

        var skillDto = _mapper.Map<SkillDto>(skill);
        return skillDto;
    }
}