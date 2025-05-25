using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class TimePicker : View
    {
        /// <summary>
        /// Ora attualmente selezionata.
        /// </summary>
        [Parameter] public TimeSpan Value { get; set; } = TimeSpan.Zero;

        /// <summary>
        /// Ora minima selezionabile.
        /// </summary>
        [Parameter] public TimeSpan MinimumTime { get; set; } = TimeSpan.Zero;

        /// <summary>
        /// Ora massima selezionabile.
        /// </summary>
        [Parameter] public TimeSpan MaximumTime { get; set; } = new TimeSpan(23, 59, 59);

        /// <summary>
        /// Evento chiamato quando l'orario cambia.
        /// </summary>
        [Parameter] public EventCallback<TimeSpan> OnTimeSelected { get; set; }

        private async Task HandleTimeChange(ChangeEventArgs e)
        {
            if (TimeSpan.TryParse(e.Value?.ToString(), out var newTime))
            {
                if (newTime >= MinimumTime && newTime <= MaximumTime)
                {
                    Value = newTime;
                    await OnTimeSelected.InvokeAsync(Value);
                }
            }
        }
    }
}

