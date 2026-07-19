using AuthService.Application.Features.Authentication.Commands.Login;
using MediatR;

namespace AuthService.Application.Features.Authentication.Commands.Refresh;

public sealed record RefreshTokenCommand(string RefreshToken) : IRequest<LoginResponse>;
