using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace SharedHelpers.DTO.CharacterDtos;

public record CharacterForCreationDto
{
    public string? UserEmail { get; set; }
    public string CharacterName { get; set; }
    public int Level { get; set; } = 1;
    public Skills? Skills { get; set; }
    public int Money { get; set; } = 1000;
}