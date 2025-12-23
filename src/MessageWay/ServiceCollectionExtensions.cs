using Microsoft.Extensions.DependencyInjection;
using MessageWay.Core;

namespace MessageWay;

/// <summary>
/// Extension methods for setting up MsgWay services in an <see cref="IServiceCollection" />.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds MsgWay services to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <param name="configureOptions">A delegate to configure the <see cref="MsgWayOptions" />.</param>
    /// <returns>The <see cref="IServiceCollection" /> so that additional calls can be chained.</returns>
    public static IServiceCollection AddMsgWay(this IServiceCollection services, Action<MsgWayOptions> configureOptions)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        if (configureOptions == null)
        {
            throw new ArgumentNullException(nameof(configureOptions));
        }

        var options = new MsgWayOptions();
        configureOptions(options);

        services.AddSingleton(options);

        services.AddHttpClient<IMsgWayClient, MsgWayClient>();

        return services;
    }
}
