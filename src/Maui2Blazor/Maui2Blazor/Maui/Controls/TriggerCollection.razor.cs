using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class TriggerCollection : ComponentBase
    {
        [Parameter] public RenderFragment ChildContent { get; set; }

        public List<TriggerBase<BindableObject>> Triggers { get; private set; } = new();

        public void AddTrigger(TriggerBase<BindableObject> trigger)
        {
            Triggers.Add(trigger);
        }
    }
}
