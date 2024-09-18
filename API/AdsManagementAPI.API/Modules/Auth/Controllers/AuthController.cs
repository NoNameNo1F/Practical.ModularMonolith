using AdsManagementAPI.API.Common;
using AdsManagementAPI.API.Configurations.Attributes;
using AdsManagementAPI.API.Modules.Auth.Dtos;
using AdsManagementAPI.Modules.Auth.Application;
using AdsManagementAPI.Modules.Auth.Application.Commands.Login;
using AdsManagementAPI.Modules.Auth.Application.Contracts;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdsManagementAPI.API.Modules.Auth.Controllers;

[ApiVersion(ApiVersions.Version1)]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthModule _authModule;

    public AuthController(IAuthModule authModule)
    {
        _authModule = authModule;
    }

    [HttpPost("login")]
    public async Task<IActionResult> GetAuthenticatedUser(LoginRequestDto request)
    {
        var user = await _authModule.ExecuteCommandAsync(new LoginCommand(request.Email, request.Password));

        return Ok(user);
    }

    [Authorize]
    [HasPrivilege("Manage Users")]
    [HttpGet("authenticate")]
    public async Task<IActionResult> GetUser()
    {
        var user = await _authModule.ExecuteQueryAsync(new TestQuery("Hihi"));

        return Ok(user);
    }
}