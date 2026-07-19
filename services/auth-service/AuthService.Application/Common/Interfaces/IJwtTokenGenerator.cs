using AuthService.Domain.Entities;

namespace AuthService.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateAccessToken(User user);

    string GenerateRefreshToken();

    string HashRefreshToken(string refreshToken);
}
