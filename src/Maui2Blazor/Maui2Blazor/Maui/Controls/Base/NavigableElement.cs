namespace Maui2Blazor.Maui.Controls
{
    public abstract class NavigableElement : StyleableElement
    {
        /// <summary>
        /// Rappresenta il servizio di navigazione associato a questo elemento.
        /// In .NET MAUI è una proprietà read-only.
        /// </summary>
        public INavigation Navigation { get; internal set; }

        /// <summary>
        /// Evento sollevato quando l'elemento sta per comparire (simile ad Appearing in MAUI Page).
        /// </summary>
        public event EventHandler Appearing;

        /// <summary>
        /// Evento sollevato quando l'elemento sta per scomparire (simile a Disappearing in MAUI Page).
        /// </summary>
        public event EventHandler Disappearing;

        ///// <summary>
        ///// Metodo virtuale chiamato quando l'elemento viene visualizzato.
        ///// Può essere overridato per eseguire logica specifica.
        ///// </summary>
        //public virtual Task OnNavigatedTo()
        //{
        //    OnAppearing();
        //    return Task.CompletedTask;
        //}

        ///// <summary>
        ///// Metodo virtuale chiamato quando l'elemento viene nascosto o viene eseguito un back.
        ///// Può essere overridato per eseguire logica specifica.
        ///// </summary>
        //public virtual Task OnNavigatedFrom()
        //{
        //    OnDisappearing();
        //    return Task.CompletedTask;
        //}

        /// <summary>
        /// Solleva l'evento Appearing.
        /// </summary>
        protected virtual void OnAppearing()
        {
            Appearing?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Solleva l'evento Disappearing.
        /// </summary>
        protected virtual void OnDisappearing()
        {
            Disappearing?.Invoke(this, EventArgs.Empty);
        }
    }

}

