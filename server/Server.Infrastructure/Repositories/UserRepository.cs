using System.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Server.API.DTOs;
using Server.Infrastructure.Data;
using Server.Infrastructure.Entities;

namespace Server.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    
    private readonly ILogger _logger;
    private readonly IDataContext _dataContext;

    public UserRepository(ILogger logger, IDataContext dataContext)
    {
        _logger = logger.ForContext<UserRepository>();
        _dataContext = dataContext;
    }

    public async Task<User?> GetUser(LoginDto loginDto)
    {
        try
        {
            return await _dataContext.Users.FirstOrDefaultAsync(user =>
                user.UserName == loginDto.Username && user.Password == loginDto.Password);
        }
        catch (Exception ex)
        {
            _logger.Error("User not found");
            return null;
        }
    }
}