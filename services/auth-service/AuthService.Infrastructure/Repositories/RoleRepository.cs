using AuthService.Application.Common.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly AuthDbContext _context;

    public RoleRepository(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<Role?> GetByNameAsync(string roleName, CancellationToken cancellationToken)
    {
        return await _context.Roles
            .FirstOrDefaultAsync(x => x.Name == roleName, cancellationToken);
    }
}