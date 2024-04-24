using DogClub.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DogClub.Entities;

public class DogClubContext: EfCoreDbContext
{
    public DogClubContext(DbContextOptions options, IOptionsSnapshot<DbContextSettings> contextSettings) : base(options, contextSettings)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DogClubDbContextConstants.Schema);

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DogClubContext).Assembly);
    }
}