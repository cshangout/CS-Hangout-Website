using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Common.Constants;
using Common.Models.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace Server.Infrastructure.Authentication.Persistence;

public class PersistenceService : IPersistenceService
{
    private readonly ILogger _logger;
    private readonly IConfiguration _configs;

    public PersistenceService(
        ILogger logger,
        IConfiguration configs)
    {
        _logger = logger;
        _configs = configs;
    }
    
    /// <summary>
    /// Create JWT to be returned upon a successful login attempt.  Parses expiration from configs.  If parse
    /// fails, 30 minutes is assigned.
    /// </summary>
    /// <returns>JwtSecurityToken</returns>
    public string GenerateUserToken()
    {
        var tokenSigning = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configs[AuthConstants.JwtSecret]));
        var getExpirationConfig =
            Int32.TryParse(_configs[AuthConstants.JwtExpirationHours], out var jwtExpirationInMinutes) ? 
                jwtExpirationInMinutes : jwtExpirationInMinutes = 30;

        // Todo: Claims
        var token = new JwtSecurityToken(
            issuer: _configs[AuthConstants.JwtIssuer],
            audience: _configs[AuthConstants.JwtAudience],
            expires: DateTime.Now.AddMinutes(jwtExpirationInMinutes),
            signingCredentials: new SigningCredentials(tokenSigning, SecurityAlgorithms.HmacSha256));

        var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
        return encodedToken;
    }
}