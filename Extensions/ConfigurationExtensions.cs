using DogClub.Settings;

namespace DogClub.Extensions;

public static class ConfigurationExtensions
{
    public static T GetSettingsOrDefault<T>(this IConfiguration configuration) where T : ISettings, new()
        => configuration.GetSection(typeof(T).Name).Get<T>() ?? new T();

    public static T ConfigureSettings<T>(this IServiceCollection service, IConfiguration configuration) where T : class, ISettings, new()
    {
        var section = configuration.GetSection(typeof(T).Name);
        service.Configure<T>(section);

        return section.Get<T>() ?? new T();
    }
}