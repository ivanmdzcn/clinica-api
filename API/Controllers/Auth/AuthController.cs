using Application.UseCases.Auth.Login;
using Application.UseCases.Auth.Me;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers.Auth;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly LoginHandler _loginHandler;
    private readonly MeHandler _meHandler;

    public AuthController(LoginHandler loginHandler, MeHandler meHandler)
    {
        _loginHandler = loginHandler;
        _meHandler = meHandler;
    }

    /// <summary>
    /// Login - Autenticación de usuario
    /// </summary>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _loginHandler.HandleAsync(request);
        return Ok(result);
    }

    /// <summary>
    /// Me - Información del usuario autenticado (consulta BD para datos actualizados)
    /// </summary>
    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> Me()
    {
        var usuarioIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (usuarioIdClaim is null || !int.TryParse(usuarioIdClaim, out int usuarioId))
            return Unauthorized(new { message = "Token inválido" });

        var request = new MeRequest { UsuarioId = usuarioId };
        var result = await _meHandler.HandleAsync(request);

        return Ok(result);
    }

    /// <summary>
    /// Me/Token - Información rápida del usuario desde el JWT (sin consultar BD)
    /// </summary>
    [HttpGet("me/token")]
    [Authorize]
    public IActionResult MeFromToken()
    {
        var user = HttpContext.User;

        var usuarioId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        var username = user.FindFirstValue(ClaimTypes.Name);
        var nombreCompleto = user.FindFirstValue(ClaimTypes.GivenName);
        var rol = user.FindFirstValue(ClaimTypes.Role);

        var permisos = user.Claims
            .Where(c => c.Type == "Permission")
            .Select(c => c.Value)
            .ToList();

        return Ok(new
        {
            UsuarioId = usuarioId,
            Username = username,
            NombreCompleto = nombreCompleto,
            Rol = rol,
            Permisos = permisos
        });
    }
}
