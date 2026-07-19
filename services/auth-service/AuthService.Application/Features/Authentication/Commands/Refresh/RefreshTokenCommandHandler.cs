using AuthService.Application.Common.Exceptions;
using AuthService.Application.Common.Interfaces;
using AuthService.Application.Features.Authentication.Commands.Login;
using AuthService.Domain.Entities;
using MediatR;

namespace AuthService.Application.Features.Authentication.Commands.Refresh;

public sealed class RefreshTokenCommandHandler
    : IRequestHandler<RefreshTokenCommand, LoginResponse>
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUnitOfWork _unitOfWork;

    public RefreshTokenCommandHandler(
        IRefreshTokenRepository refreshTokenRepository,
        IJwtTokenGenerator jwtTokenGenerator,
        IUnitOfWork unitOfWork)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _unitOfWork = unitOfWork;
    }

    public async Task<LoginResponse> Handle(
        RefreshTokenCommand request,
        CancellationToken cancellationToken)
    {
        var refreshToken = await _refreshTokenRepository.GetByTokenAsync(
            _jwtTokenGenerator.HashRefreshToken(request.RefreshToken),
            cancellationToken);

        if (refreshToken is null || !refreshToken.IsActive)
        {
            throw new UnauthorizedException("Invalid or expired refresh token.");
        }

        refreshToken.Revoke();

        var replacementToken = _jwtTokenGenerator.GenerateRefreshToken();
        await _refreshTokenRepository.AddAsync(
            new RefreshToken(
                refreshToken.UserId,
                _jwtTokenGenerator.HashRefreshToken(replacementToken),
                DateTime.UtcNow.AddDays(7),
                "Unknown Device",
                "127.0.0.1"),
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new LoginResponse(
            _jwtTokenGenerator.GenerateAccessToken(refreshToken.User),
            replacementToken);
    }
}
