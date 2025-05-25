using System.Windows.Input;
using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class TapGestureRecognizer : ComponentBase, IGestureRecognizer
    {
        [Parameter] public ICommand Command { get; set; }
        [Parameter] public object CommandParameter { get; set; }
        [Parameter] public int NumberOfTapsRequired { get; set; } = 1;

        /// <summary>
        /// Contenuto del componente.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        [CascadingParameter] public GestureRecognizerContainer ParentContainer { get; set; }

        public event EventHandler Tap;
        public event EventHandler<SwipeEventArgs> Swipe;
        public event EventHandler<PinchEventArgs> Pinch;

        protected override void OnInitialized()
        {
            ParentContainer?.AddRecognizer(this);
        }

        public void OnTap()
        {
            Command?.Execute(CommandParameter);
        }
    }
}

