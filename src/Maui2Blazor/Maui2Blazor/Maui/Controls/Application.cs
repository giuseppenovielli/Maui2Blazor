using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{

    public partial class Application : Element
    {
        private static Application _current;

        /// <summary>
        /// Istanza globale dell'applicazione.
        /// </summary>
        public static Application Current
        {
            get => _current ??= new Application();
            set => _current = value;
        }

        /// <summary>
        /// Pagina principale dell'applicazione.
        /// </summary>
        [Parameter] public RenderFragment MainPage { get; set; }

        /// <summary>
        /// Risorse globali dell'applicazione.
        /// </summary>
        public ResourceDictionary Resources { get; private set; } = new();

        /// <summary>
        /// Proprietà persistenti dell'applicazione.
        /// </summary>
        public ResourceDictionary Properties { get; private set; } = new();

        /// <summary>
        /// Tema attuale dell'applicazione.
        /// </summary>
        public AppTheme UserAppTheme { get; set; } = AppTheme.Unspecified;

        /// <summary>
        /// Evento chiamato quando l'applicazione viene avviata.
        /// </summary>
        protected virtual void OnStart() { }

        /// <summary>
        /// Evento chiamato quando l'applicazione va in background.
        /// </summary>
        protected virtual void OnSleep() { }

        /// <summary>
        /// Evento chiamato quando l'applicazione torna in primo piano.
        /// </summary>
        protected virtual void OnResume() { }

        /// <summary>
        /// Salva le proprietà persistenti.
        /// </summary>
        public Task SavePropertiesAsync()
        {
            // Simulazione del salvataggio delle proprietà
            return Task.CompletedTask;
        }
    }

    public enum AppTheme
    {
        Light,
        Dark,
        Unspecified
    }

}

