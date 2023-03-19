using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence.Initialization;

public class DatabaseInitializer : IDatabaseInitializer
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly ILogger<DatabaseInitializer> _logger;

    public DatabaseInitializer(ApplicationDbContext applicationDbContext, ILogger<DatabaseInitializer> logger)
    {
        _applicationDbContext = applicationDbContext;
        _logger = logger;
    }

    public async Task InitializeDatabasesAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Initialize database");
        if ((await _applicationDbContext.Database.GetPendingMigrationsAsync(cancellationToken)).Any())
        {
            _logger.LogInformation("Applying migrations");
            await _applicationDbContext.Database.MigrateAsync(cancellationToken);
        }
    }
}