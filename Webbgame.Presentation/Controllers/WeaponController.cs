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
		var weapons = _service.WeaponService.GetAllWeaponsAsync(trackChanges: false);
		return Ok(weapons);
	}
	
}
