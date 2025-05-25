using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Converters
{
    public partial class ConverterCollection : ComponentBase
	{
        [Parameter] public RenderFragment ChildContent { get; set; }

        public List<ValueConverter> ValueConverters { get; private set; } = new();

        public void AddValueConverter(ValueConverter valueConverter)
        {
            ValueConverters.Add(valueConverter);
        }
    }
}

