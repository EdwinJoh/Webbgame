using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Service.Contracts;
using SharedHelpers.DTO.MissionDtos;

namespace Webbgame.Presentation.Controllers;

[ApiController]
[Route("api/mission")]
public class MissionController : ControllerBase
{
    private readonly IServiceManager _service;
    public MissionController(IServiceManager service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetMissions()
    {
        var missions = await _service.MissionService.GetMissionsAsync(trackChanges: false);
        return Ok(missions);
    }

    [HttpGet("id:guid")]
    public async Task<IActionResult> GetMission(Guid id)
    {
        var mission = await _service.MissionService.GetMissionAsync(id, trackChanges: false);
        return Ok(mission);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMission([FromBody] MissionForCreateDto mission)
    {
        var missionToCreate = await _service.MissionService.CreateMissionAsync(mission, trackChanges: false);
        return NoContent();
    }
   
}
