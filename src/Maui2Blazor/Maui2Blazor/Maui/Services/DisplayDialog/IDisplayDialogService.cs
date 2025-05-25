namespace Maui2Blazor.Maui.Services
{
    public interface IDisplayDialogService
    {
        Task DisplayAlert(string title, string message, string accept);
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);
        Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);
    }
}
