using AuthService.Application.Common.Interfaces;
using AuthService.Domain.Entities;
using MediatR;
using AuthService.Application.Common.Exceptions;

namespace AuthService.Application.Features.Authentication.Register;

public class RegisterCommandHandler
    : IRequestHandler<RegisterCommand, RegisterResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtTokenGenerator jwtTokenGenerator,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
        _unitOfWork = unitOfWork;
    }

    public async Task<RegisterResponse> Handle(
        RegisterCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository
            .GetByEmailAsync(request.Email, cancellationToken);

        if (existingUser is not null)
        {
            throw new ConflictException("Email already exists.");
        }

        var passwordHash =
            _passwordHasher.HashPassword(request.Password);

        var user = User.Create(
            request.FirstName,
            request.LastName,
            request.Email,
            passwordHash);

        await _userRepository.AddAsync(user, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var accessToken =
            _jwtTokenGenerator.GenerateAccessToken(user);

        return new RegisterResponse(
            user.Id,
            user.Email,
            accessToken,
            string.Empty);
    }
}