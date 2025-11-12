using Microsoft.AspNetCore.Mvc;
using ServiceReference;
using TechTest.DTOs;
using TechTest.Services.Interfaces;

namespace TechTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {

        var result = await _authService.LoginAsync(request.UserName, request.Password, request.IPs);

        return Ok(result.@return);
    }

    // ResultCode 1 - созадлся, -1 - существует

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterNewCustomerDto request)
    {
        var result = await _authService.RegisterAsync(request.Email, request.Password, request.FirstName, request.LastName, request.Mobile, request.CountryID, request.aID, request.SignupIP);

        return Ok(result.@return);
    }
}
