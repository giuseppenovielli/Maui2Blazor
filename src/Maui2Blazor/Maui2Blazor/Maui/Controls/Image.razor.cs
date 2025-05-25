using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class Image : View
    {
        /// <summary>
        /// Percorso dell'immagine.
        /// </summary>
        [Parameter] public string Source { get; set; } = string.Empty;

        /// <summary>
        /// Specifica come l'immagine viene ridimensionata.
        /// </summary>
        [Parameter] public ImageAspect Aspect { get; set; } = ImageAspect.AspectFit;


        /// <summary>
        /// Indica se l'immagine è in fase di caricamento.
        /// </summary>
        public bool IsLoading { get; private set; } = true;


        /// <summary>
        /// Evento chiamato quando l'immagine inizia il caricamento.
        /// </summary>
        [Parameter] public EventCallback OnLoading { get; set; }

        /// <summary>
        /// Evento chiamato quando l'immagine è stata caricata.
        /// </summary>
        [Parameter] public EventCallback OnLoaded { get; set; }

        /// <summary>
        /// Evento chiamato se il caricamento dell'immagine fallisce.
        /// </summary>
        [Parameter] public EventCallback OnError { get; set; }

        /// <summary>
        /// Metodo chiamato quando l'immagine è stata caricata con successo.
        /// </summary>
        private async Task HandleLoaded()
        {
            IsLoading = false;
            await OnLoaded.InvokeAsync();
            StateHasChanged();
        }

        /// <summary>
        /// Metodo chiamato quando il caricamento dell'immagine fallisce.
        /// </summary>
        private async Task HandleError()
        {
            IsLoading = false;
            await OnError.InvokeAsync();
            StateHasChanged();
        }

        /// <summary>
        /// Genera lo stile CSS per l'elemento immagine.
        /// </summary>
        protected override string GetCombinedStyle()
        {
            var style = base.GetCombinedStyle();

            var aspectStyle = Aspect switch
            {
                ImageAspect.Fill => "object-fit: fill;",
                ImageAspect.AspectFit => "object-fit: contain;",
                ImageAspect.AspectFill => "object-fit: cover;",
                _ => "object-fit: contain;"
            };

            return style += aspectStyle;
        }
    }

    public enum ImageAspect
    {
        Fill,
        AspectFit,
        AspectFill
    }


}

