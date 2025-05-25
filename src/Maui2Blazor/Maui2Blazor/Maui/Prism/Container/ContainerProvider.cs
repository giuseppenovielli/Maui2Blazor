using Maui2Blazor.Maui.Extensions;

namespace Maui2Blazor.Maui.Prism
{
    public class ContainerProvider : IContainerProvider
    {
        readonly IServiceProvider _serviceProvider;

        public ContainerProvider(
            IServiceProvider serviceProvider)
		{
            _serviceProvider = serviceProvider;

        }

        public T Resolve<T>() where T : class
        {
            return _serviceProvider.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _serviceProvider.Resolve(type);
        }

        public Type GetTypeFromContainer(string name)
        {
            var type = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .FirstOrDefault(t => t.Name == name);
            return type;
        }

    }
}

