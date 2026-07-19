using AuthService.Application.Common.Interfaces;
using AuthService.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AuthService.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly string _issuer;
    private readonly string _audience;
    private readonly byte[] _signingKey;
    private readonly int _accessTokenExpirationMinutes;

    public JwtTokenGenerator(IConfiguration configuration)
    {
        _issuer = configuration["Jwt:Issuer"]
            ?? throw new InvalidOperationException("JWT issuer is not configured.");
        _audience = configuration["Jwt:Audience"]
            ?? throw new InvalidOperationException("JWT audience is not configured.");

        var signingKey = configuration["Jwt:Key"]
            ?? throw new InvalidOperationException("JWT signing key is not configured.");

        _signingKey = Encoding.UTF8.GetBytes(signingKey);
        if (_signingKey.Length < 32)
        {
            throw new InvalidOperationException(
                "JWT signing key must be at least 32 bytes long.");
        }

        _accessTokenExpirationMinutes = configuration.GetValue<int>(
            "Jwt:AccessTokenExpirationMinutes",
            15);
    }

    public string GenerateAccessToken(User user)
    {
        var now = DateTime.UtcNow;
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(_signingKey),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            notBefore: now,
            expires: now.AddMinutes(_accessTokenExpirationMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }

    public string HashRefreshToken(string refreshToken)
    {
        var tokenBytes = Encoding.UTF8.GetBytes(refreshToken);
        return Convert.ToHexString(SHA256.HashData(tokenBytes));
    }
}
