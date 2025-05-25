namespace Maui2Blazor.Maui.Prism
{
    public interface IContainerProvider
    {
        T Resolve<T>() where T : class;
        object Resolve(Type type);
        Type GetTypeFromContainer(string name);
    }
}

