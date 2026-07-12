using AuthService.Domain.Common;

namespace AuthService.Domain.Entities;

public class User : AuditableEntity
{
    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public string PasswordHash { get; private set; } = string.Empty;

    public bool IsActive { get; private set; } = true;

    public bool IsEmailVerified { get; private set; }

    public int FailedLoginAttempts { get; private set; }

    public DateTime? LastLoginAt { get; private set; }

    public ICollection<UserRole> UserRoles { get; private set; }
        = new List<UserRole>();

    public ICollection<RefreshToken> RefreshTokens { get; private set; }
        = new List<RefreshToken>();

    private User()
    {
    }

    private User(
        string firstName,
        string lastName,
        string email,
        string passwordHash)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
    }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string passwordHash)
    {
        return new User(
            firstName,
            lastName,
            email,
            passwordHash);
    }
}