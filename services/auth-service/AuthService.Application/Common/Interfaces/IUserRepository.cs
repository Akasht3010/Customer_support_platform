using AuthService.Domain.Entities;

namespace AuthService.Application.Common.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    Task AddAsync(User user, CancellationToken cancellationToken);
}
