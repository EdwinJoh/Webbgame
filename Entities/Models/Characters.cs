namespace Entities.Models;

public class Characters
{
    public Guid Id { get; set; }
    public string UserEmail { get; set; }
    public string CharacterName { get; set; }
    public int Level { get; set; }
    public Skills? Skills { get; set; }
    public int Money { get; set; }
    public Weapon? Weapons { get; set; }
}
