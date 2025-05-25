using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class DataTemplate : ElementTemplate
    {
        /// <summary>
        /// Costruttore che inizializza il DataTemplate con un template specifico.
        /// </summary>
        public DataTemplate(RenderFragment<object> template) : base(template) { }
    }
}

