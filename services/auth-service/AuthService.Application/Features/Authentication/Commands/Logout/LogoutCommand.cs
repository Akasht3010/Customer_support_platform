using MediatR;

namespace AuthService.Application.Features.Authentication.Commands.Logout;

public sealed record LogoutCommand(
    Guid UserId,
    string RefreshToken) : IRequest;
