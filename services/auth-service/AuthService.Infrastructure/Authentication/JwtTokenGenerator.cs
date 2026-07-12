using AuthService.Application.Common.Interfaces;
using AuthService.Domain.Entities;

namespace AuthService.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateAccessToken(User user)
    {
        // Temporary implementation
        return Guid.NewGuid().ToString();
    }
}