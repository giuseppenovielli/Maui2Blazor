using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Maui2Blazor.Maui.Controls
{
    public partial class Switch : View
    {
        private bool _isToggled;

        /// <summary>
        /// Indica se il valore dello switch è attivato.
        /// </summary>
        [Parameter]
        public bool IsToggled
        {
            get => _isToggled;
            set
            {
                if (_isToggled != value)
                {
                    _isToggled = value;
                    OnToggled.InvokeAsync(_isToggled);
                }
            }
        }

        /// <summary>
        /// Colore dello switch quando è attivato.
        /// </summary>
        [Parameter] public string OnColor { get; set; } = "#4CAF50"; // Verde

        /// <summary>
        /// Colore dello switch quando è disattivato.
        /// </summary>
        [Parameter] public string OffColor { get; set; } = "#ccc"; // Grigio

        /// <summary>
        /// Evento chiamato quando lo switch viene attivato o disattivato.
        /// </summary>
        [Parameter] public EventCallback<bool> OnToggled { get; set; }

        /// <summary>
        /// Restituisce il colore attuale del bottone in base allo stato.
        /// </summary>
        private string GetBackgroundColor() => IsToggled ? OnColor : OffColor;
    }



}

