namespace SharedHelpers.DTO.CharacterDtos.Weapons;

public record WeaponForCreation
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}