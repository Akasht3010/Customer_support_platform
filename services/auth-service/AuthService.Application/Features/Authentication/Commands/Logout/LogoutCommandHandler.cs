using AuthService.Application.Common.Interfaces;
using MediatR;

namespace AuthService.Application.Features.Authentication.Commands.Logout;

public sealed class LogoutCommandHandler : IRequestHandler<LogoutCommand>
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUnitOfWork _unitOfWork;

    public LogoutCommandHandler(
        IRefreshTokenRepository refreshTokenRepository,
        IJwtTokenGenerator jwtTokenGenerator,
        IUnitOfWork unitOfWork)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = await _refreshTokenRepository.GetByTokenAsync(
            _jwtTokenGenerator.HashRefreshToken(request.RefreshToken),
            cancellationToken);

        if (refreshToken is null || refreshToken.UserId != request.UserId || !refreshToken.IsActive)
        {
            return;
        }

        refreshToken.Revoke();
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
