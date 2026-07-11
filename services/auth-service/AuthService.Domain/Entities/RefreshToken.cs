using AuthService.Domain.Common;

namespace AuthService.Domain.Entities;

public class RefreshToken : BaseEntity
{
    public string Token { get; private set; } = string.Empty;

    public Guid UserId { get; private set; }

    public DateTime ExpiresAt { get; private set; }

    public DateTime? RevokedAt { get; private set; }

    public string DeviceName { get; private set; } = string.Empty;

    public string IpAddress { get; private set; } = string.Empty;

    public User User { get; private set; } = null!;

    private RefreshToken()
    {
    }

    public RefreshToken(
        Guid userId,
        string token,
        DateTime expiresAt,
        string deviceName,
        string ipAddress)
    {
        UserId = userId;
        Token = token;
        ExpiresAt = expiresAt;
        DeviceName = deviceName;
        IpAddress = ipAddress;
    }
}