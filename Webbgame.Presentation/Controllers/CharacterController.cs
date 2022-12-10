using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using SharedHelpers.DTO.CharacterDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbgame.Presentation.ActionFilters;

namespace Webbgame.Presentation.Controllers;

[ApiExplorerSettings(GroupName = "v3")]

public class CharacterController : ControllerBase
{
    private readonly IServiceManager _service;

    public CharacterController(IServiceManager service) => _service = service;

    [HttpGet()]
    [Route("getcharacterbyid")]
    public async Task<IActionResult> GetCharacter(int id)
    {
        var character = await _service.CharacterService.GetCharacter(id, trackChanges: false);
        return Ok(character);
    }
    [HttpGet]
    [Route("getallcharcters")]
    public async Task<IActionResult> GetCharacters()
    {
        var characters = await _service.CharacterService.GetCharacters(trackChanges: false);
        return Ok(characters);
    }

    [HttpPost("createCharacter")]
    public async Task<IActionResult> CreateCharacter([FromBody] CharacterForCreationDto character)
    {
        await _service.CharacterService.CreateCharacter(character);
        return Ok(character);
    }

    //[HttpPut("{id:guid}")]
    //public async Task<IActionResult> UpdateCharacter(Guid id, [FromBody] CharacterFotUpdateDto character)
    //{
    //    await _service.CharacterService.UpdateCharacter(id, character, trackChanges: true);
    //    return NoContent();
    //}


}
