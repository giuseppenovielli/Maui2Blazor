using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public abstract class TemplatedView : Layout
    {
        /// <summary>
        /// Il template usato per il contenuto della vista.
        /// </summary>
        [Parameter] public RenderFragment ControlTemplate { get; set; }

        /// <summary>
        /// Evento chiamato quando cambia il template.
        /// </summary>
        [Parameter] public EventCallback OnTemplateChanged { get; set; }

        /// <summary>
        /// Applica il template al contenuto della vista.
        /// </summary>
        public async Task ApplyTemplate()
        {
            await OnTemplateChanged.InvokeAsync();
            StateHasChanged();
        }
    }
}

