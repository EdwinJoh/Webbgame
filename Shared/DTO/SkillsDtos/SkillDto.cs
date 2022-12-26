namespace SharedHelpers.DTO.SkillsDtos;

public record SkillDto
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    public int RobberyLV { get; set; }
}