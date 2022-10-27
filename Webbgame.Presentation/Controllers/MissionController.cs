using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webbgame.Presentation.Controllers
{
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
        public async Task<IActionResult>GetMission(Guid id)
        {
            var mission = await _service.MissionService.GetMissionAsync(id, trackChanges: false);
            return Ok(mission);
        }

    }
}
