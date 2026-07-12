namespace AuthService.Application.Features.Authentication.Register;

public sealed record RegisterResponse(
    Guid UserId,
    string Email,
    string AccessToken,
    string RefreshToken
);