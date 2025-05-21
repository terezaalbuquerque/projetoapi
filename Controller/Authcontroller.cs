using Microsoft.AspNetCore.Mvc;
using ProjetoApi.Services;

namespace ProjetoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;

    public AuthController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // Aceita o login e retorna token
        var token = _tokenService.GenerateToken(request.Username);
        return Ok(new { token });
    }
}

public record LoginRequest(string Username, string Password);