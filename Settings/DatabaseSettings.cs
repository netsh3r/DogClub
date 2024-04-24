using JetBrains.Annotations;

namespace DogClub.Settings;

public record DatabaseSettings : ISettings
{
    public string ConnectionString { get; init; } = string.Empty;

    public DatabaseHeathCheckSettings HeathCheck { get; init; } = new();

    public bool IsEnabledAutomaticMigrations { get; init; } = true;
}

[PublicAPI]
public record DatabaseHeathCheckSettings
{
    public bool IsEnabled { get; init; }

    public string HeathCheckName { get; init; } = string.Empty;

    public string[] HeathCheckTags { get; init; } = Array.Empty<string>();
}

public interface ISettings{}

public record DbContextSettings : ISettings
{
    public bool IsEnabledSensitiveDataLogging { get; init; }
}