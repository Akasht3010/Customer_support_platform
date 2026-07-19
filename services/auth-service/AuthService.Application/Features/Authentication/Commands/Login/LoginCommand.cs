using MediatR;

namespace AuthService.Application.Features.Authentication.Commands.Login;

public record LoginCommand(
    string Email,
    string Password
) : IRequest<LoginResponse>;