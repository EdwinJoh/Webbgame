using Entities.Models;

namespace SharedHelpers.DTO.CharacterDtos;

public record CharacterDto
{
    public int Id { get; init; }
    public string UserEmail { get; init; }
    public string CharacterName { get; set; }
    public int Level { get; set; }
    public Skills Skills { get; init; }
    public int Money { get; set; }

}

