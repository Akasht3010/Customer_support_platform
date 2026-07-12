using AuthService.Domain.Entities;

namespace AuthService.Application.Common.Interfaces;

public interface IRoleRepository
{
    Task<Role?> GetByNameAsync(string roleName, CancellationToken cancellationToken);
}