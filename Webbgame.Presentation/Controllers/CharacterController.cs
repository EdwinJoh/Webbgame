using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webbgame.Presentation.Controllers;

[Route("api/character")]
[ApiController]
public class CharacterController : ControllerBase
{
    private readonly IServiceManager _service;
    public CharacterController(IServiceManager service) => _service = service;

    [HttpGet]
    [Authorize(Roles ="Manager")]
    public async Task<IActionResult> GetCharacters()
    {
        var companies = await _service.CharacterService.GetAllCharactersAsync(trackChanges: false);
        return Ok(companies);
    }

}
