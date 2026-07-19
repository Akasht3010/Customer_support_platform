namespace AuthService.Api.Contracts;

public sealed record CurrentUserResponse(
    Guid UserId,
    string Email);
