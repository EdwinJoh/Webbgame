using AutoMapper;
using Contracts;
using Entities.Models;
using Repository;
using Service.Contracts;
using SharedHelpers.DTO;

namespace Service;

public class CharacterService : ICharacterService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly RepositoryContext _repositoryContext;

    public CharacterService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, RepositoryContext context)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _repositoryContext = context;
    }
    public async Task<CharacterDto> GetCharacterAsync(string email, bool trackChanges)
    {
        var character = await _repository.Character.GetCharactersAsync(email, trackChanges);
        var characterDto = _mapper.Map<CharacterDto>(character);

        return characterDto;
    }

    public async Task<CharacterDto> CreateCharacterAsync(CharacterForCreationDto character)
    {
        var characterEntity = _mapper.Map<Characters>(character);
        characterEntity.Skills = CreateSkillForCharacter(characterEntity.Id);

        _repository.Character.CreateCharacter(characterEntity);
        await _repository.SaveAsync();

        var characterToReturn = _mapper.Map<CharacterDto>(characterEntity);

        return characterToReturn;
    }
    private Skills CreateSkillForCharacter(Guid characterId)
    {
        Skills newSkill = new();
        newSkill.CharacterId = characterId;
        newSkill.RobberyLV = 1;

        return newSkill;
    }



}
