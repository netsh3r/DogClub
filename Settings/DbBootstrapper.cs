using DogClub.Entities;
using DogClub.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DogClub.Settings;

public static class DbBootstrapper
{
    public static IServiceCollection AddPostgreSql<TContext>(this IServiceCollection services,
        IConfiguration configuration)
        where TContext : EfCoreDbContext
    {
        var dbSettings = services.ConfigureSettings<DatabaseSettings>(configuration);
        services.ConfigureSettings<DbContextSettings>(configuration);
        services.AddDbContext<TContext>((provider, options) =>
        {
            options.UseNpgsql(
                dbSettings.ConnectionString,
                optionsBuilder => optionsBuilder.MigrationsHistoryTable(DogClubDbContextConstants.MigrationsHistoryTable,
                    DogClubDbContextConstants.Schema));
            var interceptor = provider.GetServices<IInterceptor>().ToArray();
            if (interceptor.Any())
            {
                options.AddInterceptors(interceptor);
            }
        }, ServiceLifetime.Transient);
        services.AddTransient<EfCoreDbContext>(provider => provider.GetRequiredService<TContext>());
        return services;
    }
}