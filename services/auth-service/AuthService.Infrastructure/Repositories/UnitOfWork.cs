using AuthService.Application.Common.Interfaces;
using AuthService.Infrastructure.Persistence;

namespace AuthService.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AuthDbContext _context;

    public UnitOfWork(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
