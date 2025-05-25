namespace Maui2Blazor.Maui.Controls
{
    public partial class BoxView : View
    {

        /// <summary>
        /// Metodo che gestisce il click sul BoxView.
        /// </summary>
        private async Task HandleClick()
        {
            await OnClick.InvokeAsync();
        }
    }
}

