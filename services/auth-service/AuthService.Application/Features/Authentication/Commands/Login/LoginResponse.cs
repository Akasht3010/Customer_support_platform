namespace AuthService.Application.Features.Authentication.Commands.Login;

public record LoginResponse(
    string AccessToken,
    string RefreshToken
);