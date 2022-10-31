using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using SharedHelpers.DTO.CharacterDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbgame.Presentation.ActionFilters;

namespace Webbgame.Presentation.Controllers

{
    [Route("api/character")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v2")]

    public class CharacterController :ControllerBase
    {
        private readonly IServiceManager _service;

        public CharacterController(IServiceManager service) => _service = service;

        [HttpGet()]
        [Route("email")]
        public async Task<IActionResult> GetCharacter(string email)
        {
            var character = await _service.CharacterService.GetCharacterAsync(email, trackChanges: false);
            return Ok(character);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCharacter([FromBody] CharacterForCreationDto character)
        {
            await _service.CharacterService.CreateCharacterAsync(character);
            return Ok(character);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCharacter(Guid id, [FromBody] CharacterFotUpdateDto character)
        {
            await _service.CharacterService.UpdateCharacter(id, character, trackChanges: true);
            return NoContent();
        }


    }
}
