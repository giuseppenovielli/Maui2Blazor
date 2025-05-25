using Maui2Blazor.Utils;
using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class Setter : ComponentBase
	{
        [Parameter] public string Property { get; set; }
        [Parameter] public object Value { get; set; }

        [CascadingParameter] public StyleMaui ParentStyle { get; set; }
        [CascadingParameter] public DataTrigger ParentDataTrigger { get; set; }

        protected override void OnInitialized()
        {
            DebugHelpers.WriteLine($"✅ Setter rilevato");
            DebugHelpers.WriteLine(Property);
            DebugHelpers.WriteLine(Value);

            ParentStyle?.AddSetter(Property, Value);
            ParentDataTrigger?.AddSetter(Property, Value);
        }

    }
}

