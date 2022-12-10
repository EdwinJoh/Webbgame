using Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace SharedHelpers.DTO.CharacterDtos;

public record CharacterForCreationDto
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    [Required]
    public string CharacterName { get; set; }
    public int Level { get; set; } = 1;
    public Skills? Skills { get; set; }
    public int Money { get; set; } = 1000;
}
