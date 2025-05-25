using Maui2Blazor.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Maui2Blazor.Maui.Extensions
{
    public static class IServiceProviderExtensions
    {
        public static T Resolve<T>(this IServiceProvider serviceProvider) where T : class
        {
            return serviceProvider?.GetService<T>() ?? throw new InvalidOperationException($"Service {typeof(T).Name} not found.");
        }

        public static T ResolveRequired<T>(this IServiceProvider serviceProvider) where T : class
        {
            return serviceProvider?.GetRequiredService<T>();
        }

        public static object Resolve(this IServiceProvider serviceProvider, Type type)
        {
            try
            {
                DebugHelpers.WriteLine($"Servizio richiesto: {type}");
                var service = serviceProvider?.GetRequiredService(type);
                DebugHelpers.WriteLine($"Servizio ottenuto: {service}");
                return service;
            }
            catch (InvalidOperationException ex)
            {
                DebugHelpers.WriteLine($"Errore: {ex.Message}");
            }

            return null;
        }
    }
}

