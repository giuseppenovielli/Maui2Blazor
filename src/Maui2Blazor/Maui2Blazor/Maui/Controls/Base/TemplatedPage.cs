using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public abstract class TemplatedPage : Page
	{
        /// <summary>
        /// Template personalizzabile per la pagina.
        /// </summary>
        [Parameter] public RenderFragment ControlTemplate { get; set; }
    }
}

