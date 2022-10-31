using System.ComponentModel.DataAnnotations;

namespace SharedHelpers.DTO.UserDto;

public class UserLogin
{
    public int Id { get; set; }
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
