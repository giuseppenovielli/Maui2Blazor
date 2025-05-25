using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class CheckBox : View
    {
        /// <summary>
        /// Proprietà di stato della CheckBox (bindabile).
        /// </summary>
        [Parameter]
        public bool IsChecked { get; set; }

        /// <summary>
        /// Evento che si attiva quando lo stato della CheckBox cambia.
        /// </summary>
        [Parameter]
        public EventCallback<bool> IsCheckedChanged { get; set; }

        /// <summary>
        /// Colore del CheckBox (bindabile).
        /// </summary>
        [Parameter]
        public string Color { get; set; } = "#007AFF";

        private void HandleCheckedChanged(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value?.ToString(), out bool newValue))
            {
                IsChecked = newValue;
                IsCheckedChanged.InvokeAsync(newValue); // Notifica il parent del cambiamento
            }
        }

        protected override string GetCombinedStyle()
        {
            var style = base.GetCombinedStyle();
            return style += $"accent-color: {Color}; width: 20px; height: 20px;";
        }
    }
}
