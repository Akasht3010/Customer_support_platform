using MediatR;

namespace AuthService.Application.Features.Authentication.Register;

public sealed record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<RegisterResponse>;