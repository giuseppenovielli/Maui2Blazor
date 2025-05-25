namespace Maui2Blazor.Maui.Prism
{
    public interface INavigationParameters : IEnumerable<KeyValuePair<string, object>>
    {
        bool ContainsKey(string key);
        T GetValue<T>(string key);
        void Add(string key, object value);
        IDictionary<string, object> GetAllParameters();
        object this[string key] { get; set; }
        NavigationMode GetNavigationMode();
    }

    public enum NavigationMode
    {
        New,
        Back
    }
}

