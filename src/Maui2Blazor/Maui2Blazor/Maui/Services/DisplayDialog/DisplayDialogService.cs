namespace Maui2Blazor.Maui.Services
{
    public class DisplayDialogService : IDisplayDialogService
    {
        private TaskCompletionSource<bool> _alertTcs;
        private TaskCompletionSource<string> _actionSheetTcs;

        // Stato per gli Alert
        public string AlertTitle { get; private set; }
        public string AlertMessage { get; private set; }
        public string AlertAccept { get; private set; }
        public string AlertCancel { get; private set; }
        public bool ShowAlert { get; private set; }

        // Stato per gli Action Sheet
        public string ActionSheetTitle { get; private set; }
        public string ActionSheetCancel { get; private set; }
        public string ActionSheetDestruction { get; private set; }
        public string[] ActionSheetButtons { get; private set; }
        public bool ShowActionSheet { get; private set; }

        public event Action OnDisplayChanged;

        // Implementazione di DisplayAlert
        public Task DisplayAlert(string title, string message, string accept)
        {
            AlertTitle = title;
            AlertMessage = message;
            AlertAccept = accept;
            AlertCancel = null;
            ShowAlert = true;
            _alertTcs = new TaskCompletionSource<bool>();

            OnDisplayChanged?.Invoke();
            return _alertTcs.Task;
        }

        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            AlertTitle = title;
            AlertMessage = message;
            AlertAccept = accept;
            AlertCancel = cancel;
            ShowAlert = true;
            _alertTcs = new TaskCompletionSource<bool>();

            OnDisplayChanged?.Invoke();
            return _alertTcs.Task;
        }

        public void AcceptAlert()
        {
            _alertTcs?.SetResult(true);
            ShowAlert = false;
            OnDisplayChanged?.Invoke();
        }

        public void CancelAlert()
        {
            _alertTcs?.SetResult(false);
            ShowAlert = false;
            OnDisplayChanged?.Invoke();
        }

        // Implementazione di DisplayActionSheet
        public Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            ActionSheetTitle = title;
            ActionSheetCancel = cancel;
            ActionSheetDestruction = destruction;
            ActionSheetButtons = buttons;
            ShowActionSheet = true;
            _actionSheetTcs = new TaskCompletionSource<string>();

            OnDisplayChanged?.Invoke();
            return _actionSheetTcs.Task;
        }

        public void SelectActionSheetOption(string option)
        {
            _actionSheetTcs?.SetResult(option);
            ShowActionSheet = false;
            OnDisplayChanged?.Invoke();
        }
    }
}
