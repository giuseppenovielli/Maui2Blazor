using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public abstract class StyleableElement : Element
    {
        /// <summary>
        /// Classe CSS assegnata all'elemento.
        /// </summary>
        [Parameter] public string Class { get; set; } = string.Empty;

        /// <summary>
        /// Dizionario delle risorse personalizzate.
        /// </summary>
        [Parameter] public ResourceDictionary Resources { get; set; } = new();

        /// <summary>
        /// Imposta una risorsa dinamica.
        /// </summary>
        public void SetDynamicResource(string key, object value)
        {
            Resources[key] = value;
            StateHasChanged();
        }

        /// <summary>
        /// Stile CSS personalizzato.
        /// </summary>
        [Parameter]
        public string Style { get; set; } = string.Empty;

        /// <summary>
        /// Ottiene una risorsa dal dizionario.
        /// </summary>
        public object GetResource(string key)
        {
            return Resources.ContainsKey(key) ? Resources[key] : null;
        }

        /// <summary>
        /// Genera lo stile CSS combinato per l'elemento.
        /// </summary>
        protected virtual string GetCombinedStyle()
        {
            return $"{Style} {GetResource("DynamicStyle") ?? ""}".Trim();
        }
    }

}

