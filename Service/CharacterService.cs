using System.Xml.Schema;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Repository;
using Service.Contracts;
using SharedHelpers.DTO.CharacterDtos;

namespace Service;

internal sealed class CharacterService : ICharacterService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;
    private readonly RepositoryContext _repositoryContext;

    public CharacterService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper,
        RepositoryContext context)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
        _repositoryContext = context;
    }


    public async Task<List<CharacterDto>> GetCharacters(bool trackChanges)
    {
        var characters = await _repository.Character.GetCharactersAsync(trackChanges);

        var charactersDtos = _mapper.Map<List<CharacterDto>>(characters);

        return charactersDtos;
    }

    public async Task<CharacterDto> GetCharacter(int id, bool trackChanges)
    {
        var character = await _repository.Character.GetCharacterById(id, trackChanges);

        if (character == null)
            throw new CharacterNotFoundException(id);

        var characterDto = _mapper.Map<CharacterDto>(character);
        return characterDto;
    }

    public async Task<CharacterDto> CreateCharacter(CharacterForCreationDto character)
    {
        var characterEntity = _mapper.Map<Characters>(character);
        _repository.Character.CreateCharacter(characterEntity);
        await _repository.SaveAsync();

        var characters = await _repository.Character.GetCharactersAsync(trackChanges: false);
        var test = characters.FirstOrDefault(x => x.UserEmail == character.UserEmail);
        var skill = new Skills
        {
            CharacterId = test.Id,
            RobberyLV = 1
        };

        characterEntity.Skills = skill;
        _repository.Skill.CreateSkill(skill);

        await _repository.SaveAsync();
        var user = _repositoryContext.Users.SingleOrDefault(x => x.Email.Equals(character.UserEmail));
        user.GameTag = character.CharacterName;

        await _repositoryContext.SaveChangesAsync();
        var characterReturn = _mapper.Map<CharacterDto>(characterEntity);
        return characterReturn;
    }
}