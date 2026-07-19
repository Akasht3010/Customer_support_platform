using AuthService.Domain.Entities;

namespace AuthService.Application.Common.Interfaces;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetByTokenAsync(
        string token,
        CancellationToken cancellationToken);

    Task AddAsync(
        RefreshToken refreshToken,
        CancellationToken cancellationToken);
}
