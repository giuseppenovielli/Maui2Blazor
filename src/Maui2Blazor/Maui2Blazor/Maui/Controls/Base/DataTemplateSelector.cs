using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public abstract class DataTemplateSelector
    {
        public abstract RenderFragment<object> SelectTemplate(object item);
    }
}

