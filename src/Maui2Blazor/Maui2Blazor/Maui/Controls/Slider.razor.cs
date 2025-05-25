using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class Slider : View
    {
        private double _value;

        /// <summary>
        /// Valore attuale dello slider.
        /// </summary>
        [Parameter]
        public double Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnValueChanged.InvokeAsync(_value);
                }
            }
        }

        /// <summary>
        /// Valore minimo selezionabile.
        /// </summary>
        [Parameter] public double Minimum { get; set; } = 0;

        /// <summary>
        /// Valore massimo selezionabile.
        /// </summary>
        [Parameter] public double Maximum { get; set; } = 100;

        /// <summary>
        /// Passo dello slider.
        /// </summary>
        [Parameter] public double Step { get; set; } = 1;

        /// <summary>
        /// Evento chiamato quando il valore cambia.
        /// </summary>
        [Parameter] public EventCallback<double> OnValueChanged { get; set; }

        /// <summary>
        /// Aggiorna il valore al cambiamento dell'input.
        /// </summary>
        private async Task HandleValueChanged(ChangeEventArgs e)
        {
            if (double.TryParse(e.Value?.ToString(), out var newValue))
            {
                Value = newValue;
                await OnValueChanged.InvokeAsync(Value);
            }
        }
    }

}

