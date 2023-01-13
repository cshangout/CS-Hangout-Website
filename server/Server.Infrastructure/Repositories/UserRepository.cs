using System.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
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
}