using Maui2Blazor.Maui.Prism;
using Maui2Blazor.Maui.Views;
using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Pages
{
    public partial class BlazorMauiPage : ContentPageBase
    {
        [Inject]
        private INavigationService NavigationService { get; set; }

        public BlazorMauiPage()
		{
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender)
                Maui2BlazorApp.NavigateToFirstPage(NavigationService);
        }
    }
}

