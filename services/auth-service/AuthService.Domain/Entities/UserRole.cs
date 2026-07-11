using AuthService.Domain.Common;

namespace AuthService.Domain.Entities;

public class UserRole : BaseEntity
{
    public Guid UserId { get; private set; }

    public Guid RoleId { get; private set; }

    public DateTime AssignedAt { get; private set; } = DateTime.UtcNow;

    public User User { get; private set; } = null!;

    public Role Role { get; private set; } = null!;

    private UserRole()
    {
    }

    public UserRole(Guid userId, Guid roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
}