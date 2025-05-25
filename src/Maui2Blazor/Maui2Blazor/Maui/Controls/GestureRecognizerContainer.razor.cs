using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class GestureRecognizerContainer : ComponentBase
    {
        [Parameter] public RenderFragment ChildContent { get; set; }

        public List<IGestureRecognizer> Recognizers { get; private set; } = new();

        public void AddRecognizer(IGestureRecognizer recognizer)
        {
            Recognizers.Add(recognizer);
        }

        public void TriggerTapRecognizers()
        {
            foreach (var recognizer in Recognizers)
            {
                if (recognizer is TapGestureRecognizer tapRecognizer)
                {
                    tapRecognizer.OnTap();
                }
            }
        }
    }
}
