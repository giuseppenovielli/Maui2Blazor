using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class StyleMaui : ComponentBase
    {
        /// <summary>
        /// Tipo di controllo a cui si applica lo stile (es. "Button", "Label", ecc.).
        /// </summary>
        [Parameter] public string TargetType { get; set; }

        /// <summary>
        /// Indica se lo stile si applica ai tipi derivati.
        /// </summary>
        [Parameter] public bool ApplyToDerivedTypes { get; set; } = false;

        /// <summary>
        /// Stile di base da cui questo stile eredita.
        /// </summary>
        [Parameter] public StyleMaui BasedOn { get; set; }

        /// <summary>
        /// Contenuto del componente (supporta `<Setter>`).
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Collezione di Setter per definire proprietà di stile.
        /// </summary>
        public List<Setter> Setters { get; private set; } = new();

        /// <summary>
        /// Dizionario degli stili applicati.
        /// </summary>
        public Dictionary<string, object> Properties { get; private set; } = new();

        protected override void OnInitialized()
        {
            // Inizializza gli stili ereditati
            if (BasedOn != null)
            {
                foreach (var setter in BasedOn.Setters)
                {
                    Properties[setter.Property] = setter.Value;
                }
            }

            // Applica gli stili definiti in questo componente
            foreach (var setter in Setters)
            {
                Properties[setter.Property] = setter.Value;
            }
        }

        /// <summary>
        /// Converte lo stile in una stringa CSS utilizzabile.
        /// </summary>
        public string GetStyleString()
        {
            return string.Join("; ", Properties.Select(p => $"{p.Key.ToLowerInvariant()}: {p.Value}")) + ";";
        }

        /// <summary>
        /// Aggiunge un nuovo Setter agli stili definiti.
        /// </summary>
        public void AddSetter(string property, object value)
        {
            Setters.Add(new Setter { Property = property, Value = value });
            Properties[property] = value;
        }
    }



}

