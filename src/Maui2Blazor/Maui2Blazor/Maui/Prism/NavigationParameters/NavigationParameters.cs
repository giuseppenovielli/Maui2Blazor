using System.Collections;
using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Prism
{
    public class NavigationParameters : INavigationParameters
    {
        private readonly Dictionary<string, object> _parameters = new();
        private NavigationMode _navigationMode = NavigationMode.New;

        public NavigationParameters()
        {

        }

        public NavigationParameters(NavigationManager navManager)
        {
            _navigationMode = NavigationMode.New; // Default
            navManager.LocationChanged += (sender, args) =>
            {
                _navigationMode = NavigationMode.Back;
            };
        }

        public NavigationParameters(IDictionary<string, object> parameters)
        {
            foreach (var param in parameters)
            {
                _parameters[param.Key] = param.Value;
            }
        }

        public bool ContainsKey(string key) => _parameters.ContainsKey(key);

        public T GetValue<T>(string key)
        {
            if (_parameters.TryGetValue(key, out var value) && value is T typedValue)
            {
                return typedValue;
            }
            return default;
        }

        public void Add(string key, object value) => _parameters[key] = value;

        public IDictionary<string, object> GetAllParameters() => _parameters;

        public object this[string key]
        {
            get
            {
                if (_parameters.TryGetValue(key, out var value))
                    return value;
                throw new KeyNotFoundException($"Il parametro '{key}' non è stato trovato.");
            }
            set => _parameters[key] = value;
        }

        // Implementazione di IEnumerable per supportare gli inizializzatori di raccolta
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => _parameters.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public NavigationMode GetNavigationMode() => _navigationMode;
    }
}

