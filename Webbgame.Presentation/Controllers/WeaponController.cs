using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using SharedHelpers.DTO.CharacterDtos.Weapons;

namespace Webbgame.Presentation.Controllers;

[Route("weapon")]
public class WeaponController : ControllerBase
{
    private readonly IServiceManager _service;

    public WeaponController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetWapons()
    {
        var weapons = await _service.WeaponService.GetAllWeaponsAsync(false);
        return Ok(weapons);
    }

    [HttpGet("id:int")]
    public async Task<IActionResult> GetWeapon(string name)
    {
        var weapon = await _service.WeaponService.GetWeaponAsync(name, false);
        return Ok(weapon);
    }

    [HttpPost("createWeapon")]
    public async Task<IActionResult> CreateWeapon([FromBody] WeaponForCreation weapon)
    {
        var weaponCreated = await _service.WeaponService.CreateWeponAsync(weapon, false);
        return NoContent();
    }
}