using AuthService.Application.Common.Interfaces;
using AuthService.Application.Common.Exceptions;
using AuthService.Domain.Entities;
using MediatR;

namespace AuthService.Application.Features.Authentication.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUnitOfWork _unitOfWork;

    public LoginCommandHandler(
        IUserRepository userRepository,
        IRefreshTokenRepository refreshTokenRepository,
        IPasswordHasher passwordHasher,
        IJwtTokenGenerator jwtTokenGenerator,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
        _unitOfWork = unitOfWork;
    }

    public async Task<LoginResponse> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(
            request.Email,
        cancellationToken);

        if (user is null)
        {
            throw new UnauthorizedException("Invalid email or password.");
        }

        var isPasswordValid = _passwordHasher.VerifyPassword(
            request.Password,
            user.PasswordHash);

        if (!isPasswordValid)
        {
            throw new UnauthorizedException("Invalid email or password.");
        }

        var accessToken = _jwtTokenGenerator.GenerateAccessToken(user);

        var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();

        var refreshTokenEntity = new RefreshToken(
            user.Id,
            _jwtTokenGenerator.HashRefreshToken(refreshToken),
            DateTime.UtcNow.AddDays(7),
            "Unknown Device",
            "127.0.0.1"
        );

        await _refreshTokenRepository.AddAsync(
            refreshTokenEntity,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new LoginResponse(
            accessToken,
            refreshToken);
    }
}
