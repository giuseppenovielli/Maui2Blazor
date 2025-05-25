using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class DatePicker : View
    {
        /// <summary>
        /// Data attualmente selezionata.
        /// </summary>
        [Parameter] public DateTime Value { get; set; }

        /// <summary>
        /// Data minima selezionabile.
        /// </summary>
        [Parameter] public DateTime MinimumDate { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Data massima selezionabile.
        /// </summary>
        [Parameter] public DateTime MaximumDate { get; set; } = DateTime.MaxValue;

        /// <summary>
        /// Formato della data.
        /// </summary>
        [Parameter] public string Format { get; set; } = "yyyy-MM-dd";

        /// <summary>
        /// Evento chiamato quando la data cambia.
        /// </summary>
        [Parameter] public EventCallback<DateTime> OnDateSelected { get; set; }

        private async Task HandleDateChange(ChangeEventArgs e)
        {
            if (DateTime.TryParse(e.Value.ToString(), out var newDate))
            {
                if (newDate >= MinimumDate && newDate <= MaximumDate)
                {
                    Value = newDate;
                    await OnDateSelected.InvokeAsync(Value);
                }
            }
        }
    }

}

