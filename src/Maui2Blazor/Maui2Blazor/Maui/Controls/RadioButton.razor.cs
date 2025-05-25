using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class RadioButton : TemplatedView
    {
        private bool _isChecked;

        /// <summary>
        /// Indica se il radio button è selezionato.
        /// </summary>
        [Parameter]
        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    OnCheckedChanged.InvokeAsync(_isChecked);
                }
            }
        }

        /// <summary>
        /// Nome del gruppo di radio button.
        /// </summary>
        [Parameter] public string GroupName { get; set; }

        /// <summary>
        /// Testo associato al radio button.
        /// </summary>
        [Parameter] public string Text { get; set; }

        /// <summary>
        /// Valore associato al radio button.
        /// </summary>
        [Parameter] public object Value { get; set; }

        /// <summary>
        /// Evento chiamato quando il radio button viene selezionato.
        /// </summary>
        [Parameter] public EventCallback<bool> OnCheckedChanged { get; set; }
    }



}

