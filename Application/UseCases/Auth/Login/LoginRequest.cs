namespace Application.UseCases.Auth.Login;

public class LoginRequest
{
    public string Username { get; init; } = default!;
    public string Password { get; init; } = default!;
}
