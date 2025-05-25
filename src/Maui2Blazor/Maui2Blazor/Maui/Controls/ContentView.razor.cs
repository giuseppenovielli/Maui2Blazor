using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class ContentView : TemplatedView
    {
        [Parameter]
        public RenderFragment Content { get; set; }

        protected override void OnParametersSet()
        {
            // Se il parametro 'Content' non è stato impostato esplicitamente,
            // utilizziamo il valore passato come ChildContent.
            if (Content == null && ChildContent != null)
            {
                Content = ChildContent;
            }
        }
    }
}

