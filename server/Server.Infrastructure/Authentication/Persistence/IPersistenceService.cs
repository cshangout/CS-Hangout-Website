using System.IdentityModel.Tokens.Jwt;

namespace Server.Infrastructure.Authentication.Persistence;

public interface IPersistenceService
{
    public string GenerateUserToken();
}