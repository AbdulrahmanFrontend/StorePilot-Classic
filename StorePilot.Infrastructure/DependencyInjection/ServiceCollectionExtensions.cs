using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StorePilot.Application.Services.Backup;
using StorePilot.Infrastructure.Backup;
using StorePilot.Infrastructure.Data;
using StorePilot.Infrastructure.Storage;

namespace StorePilot.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStorePilotInfrastructure(
        this IServiceCollection services,
        StorePilotPaths paths)
    {
        ArgumentNullException.ThrowIfNull(paths);

        paths.EnsureDirectories();

        services.AddDbContext<StorePilotDbContext>(
            options =>
            {
                options.UseSqlite(
                    $"Data Source={paths.DatabaseFilePath}");
            });

        services.AddSingleton<IBackupService>(
            _ => new FileBackupService(
                paths.DatabaseFilePath,
                paths.BackupDirectory));

        return services;
    }
}
