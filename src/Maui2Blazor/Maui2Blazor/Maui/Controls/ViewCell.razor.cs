using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class ViewCell : ComponentBase
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
    }

}

