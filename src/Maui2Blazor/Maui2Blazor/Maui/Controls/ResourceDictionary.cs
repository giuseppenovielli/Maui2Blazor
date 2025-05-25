using System.Collections;
namespace Maui2Blazor.Maui.Controls
{
    public class ResourceDictionary : IDictionary<string, object>
    {
        private readonly Dictionary<string, object> _resources = new();

        /// <summary>
        /// Dizionari annidati per risorse estese.
        /// </summary>
        public List<ResourceDictionary> MergedDictionaries { get; } = new();

        /// <summary>
        /// Aggiunge una risorsa al dizionario.
        /// </summary>
        public void Add(string key, object value)
        {
            if (!_resources.ContainsKey(key))
                _resources.Add(key, value);
        }

        /// <summary>
        /// Rimuove una risorsa.
        /// </summary>
        public bool Remove(string key) => _resources.Remove(key);

        /// <summary>
        /// Controlla se il dizionario contiene una determinata chiave.
        /// </summary>
        public bool ContainsKey(string key) => _resources.ContainsKey(key);

        /// <summary>
        /// Ottiene un valore se esiste nel dizionario.
        /// </summary>
        public bool TryGetValue(string key, out object value) => _resources.TryGetValue(key, out value);

        /// <summary>
        /// Ottiene o imposta una risorsa tramite la chiave.
        /// </summary>
        public object this[string key]
        {
            get
            {
                if (_resources.ContainsKey(key))
                    return _resources[key];

                // Cerca nelle MergedDictionaries
                foreach (var dict in MergedDictionaries)
                {
                    if (dict.TryGetValue(key, out var value))
                        return value;
                }

                throw new KeyNotFoundException($"Risorsa con chiave '{key}' non trovata.");
            }
            set => _resources[key] = value;
        }

        /// <summary>
        /// Cancella tutte le risorse.
        /// </summary>
        public void Clear() => _resources.Clear();

        /// <summary>
        /// Ritorna il numero di risorse nel dizionario.
        /// </summary>
        public int Count => _resources.Count;

        /// <summary>
        /// Ritorna la lista delle chiavi nel dizionario.
        /// </summary>
        public ICollection<string> Keys => _resources.Keys;

        /// <summary>
        /// Ritorna la lista dei valori nel dizionario.
        /// </summary>
        public ICollection<object> Values => _resources.Values;

        public void Add(KeyValuePair<string, object> item) => Add(item.Key, item.Value);
        public bool Contains(KeyValuePair<string, object> item) => _resources.ContainsKey(item.Key);
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex) => throw new NotImplementedException();
        public bool Remove(KeyValuePair<string, object> item) => Remove(item.Key);
        public bool IsReadOnly => false;
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => _resources.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _resources.GetEnumerator();
    }

}

