using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Webbgame.Presentation.Controllers;

[ApiController]
[Route("api/weapon")]
public class WeaponController : ControllerBase
{
    private readonly IServiceManager _service;
	public WeaponController(IServiceManager service) => _service = service;

	[HttpGet]
	public async Task<IActionResult> GetWapons()
	{
		var weapons = await _service.WeaponService.GetAllWeaponsAsync(trackChanges: false);
		return Ok(weapons);
	}
	[HttpGet("id:guid")]
	public async Task<IActionResult> GetWeapon(string name)
	{
		var weapon = await _service.WeaponService.GetWeaponAsync(name,trackChanges:false);
		return Ok(weapon);
	}
	
}
