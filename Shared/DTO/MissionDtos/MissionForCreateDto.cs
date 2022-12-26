using System.ComponentModel.DataAnnotations;

namespace SharedHelpers.DTO.MissionDtos;

public class MissionForCreateDto
{
    public int Id { get; set; }

    [Required] public string Name { get; set; }

    public int Money { get; set; }
}