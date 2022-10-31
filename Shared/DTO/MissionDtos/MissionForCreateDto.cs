using System.ComponentModel.DataAnnotations;

namespace SharedHelpers.DTO.MissionDtos;

public class MissionForCreateDto
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int Money { get; set; }
}
