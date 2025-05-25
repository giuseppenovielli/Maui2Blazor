using Maui2Blazor.Maui.Services;
using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class DisplayDialog : ComponentBase
	{
        DisplayDialogService _service;

        private bool _showAlert;
        private string _alertTitle;
        private string _alertMessage;
        private string _alertAccept;
        private string _alertCancel;

        private bool _showActionSheet;
        private string _actionSheetTitle;
        private string _actionSheetCancel;
        private string _actionSheetDestruction;
        private string[] _actionSheetButtons;

        protected override void OnInitialized()
        {
            _service = Service as DisplayDialogService;
            if (_service == null) return;

            _service.OnDisplayChanged += () =>
            {
                _alertTitle = _service.AlertTitle;
                _alertMessage = _service.AlertMessage;
                _alertAccept = _service.AlertAccept;
                _alertCancel = _service.AlertCancel;
                _showAlert = _service.ShowAlert;

                _actionSheetTitle = _service.ActionSheetTitle;
                _actionSheetCancel = _service.ActionSheetCancel;
                _actionSheetDestruction = _service.ActionSheetDestruction;
                _actionSheetButtons = _service.ActionSheetButtons;
                _showActionSheet = _service.ShowActionSheet;

                StateHasChanged();
            };
        }

        private void AcceptAlert() => _service.AcceptAlert();
        private void CancelAlert() => _service.CancelAlert();
        private void SelectActionSheetOption(string option) => _service.SelectActionSheetOption(option);
    }
}

