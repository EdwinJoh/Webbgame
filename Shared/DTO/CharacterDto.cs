using Entities.Models;

namespace SharedHelpers.DTO;

public record CharacterDto(Guid Id, string CharacterName, int Level, Skills? Skills, int Money);

