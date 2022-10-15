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
    public IActionResult GetCharacters()
    {
        var companies = _service.CharacterService.GetAllCharacters(trackChanges: false);

        return Ok(companies);
    }
}
