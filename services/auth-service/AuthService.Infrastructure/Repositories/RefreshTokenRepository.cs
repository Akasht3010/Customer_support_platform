using AuthService.Application.Common.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly AuthDbContext _context;

    public RefreshTokenRepository(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<RefreshToken?> GetByTokenAsync(
        string token,
        CancellationToken cancellationToken)
    {
        return await _context.RefreshTokens
            .Include(refreshToken => refreshToken.User)
            .SingleOrDefaultAsync(
                refreshToken => refreshToken.Token == token,
                cancellationToken);
    }

    public async Task AddAsync(
        RefreshToken refreshToken,
        CancellationToken cancellationToken)
    {
        await _context.RefreshTokens.AddAsync(refreshToken, cancellationToken);
    }
}
