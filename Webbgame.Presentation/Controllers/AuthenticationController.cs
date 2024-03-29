﻿using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using SharedHelpers.DTO.UserDto;
using SheredHelpers;

namespace Webbgame.Presentation.Controllers;

public class AuthenticationController : ControllerBase
{
    private readonly IAuthService _autService;

    public AuthenticationController(IAuthService autService)
    {
        _autService = autService;
    }

    /// <summary>
    ///     Register an user to our application.
    /// </summary>
    [HttpPost("register")]
    public async Task<ActionResult<ServiceResponse<int>>> Register([FromBody] UserRegister request)
    {
        var respons = await _autService.Register(new User
            {
                Email = request.Email
            },
            request.Password);

        if (!respons.Success)
            return BadRequest(respons);

        return Ok(respons);
    }

    /// <summary>
    ///     Log in an user to our application.
    /// </summary>
    [HttpPost("login")]
    public async Task<ActionResult<ServiceResponse<string>>> Login([FromBody] UserLogin request)
    {
        var respons = await _autService.Login(request.Email, request.Password);

        if (!respons.Success)
            return BadRequest(respons);

        return Ok(respons);
    }
}