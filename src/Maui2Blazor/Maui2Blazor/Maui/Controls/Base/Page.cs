using Maui2Blazor.Maui.Extensions;
using Maui2Blazor.Maui.Prism;
using Maui2Blazor.Utils;
using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public abstract class Page : VisualElement, IDisposable
    {
        /// <summary>
        /// Titolo della pagina.
        /// </summary>
        [Parameter]
        public string Title { get; set; } = string.Empty;


        /// <summary>
        /// _Parameters di tipo NavigationParameters
        /// </summary>
        NavigationParameters _navigationParameters;


        /// <summary>
        /// Parametrii di Prism
        /// </summary>
        Dictionary<string, object> _parametersBackup;
        [Parameter] public Dictionary<string, object> _Parameters { get; set; }

        /// <summary>
        /// ViewModel passato esplicitamente tramite navigazione (PushAsync).
        /// </summary>
        [Parameter] public object _ViewModel { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            DebugHelpers.WriteLine("OnInitialized ->" + this);

            var navPage = Maui2BlazorApp.NavigationPage;
            if (navPage == null)
                return;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            Console.WriteLine("\n");
            DebugHelpers.WriteLine(this);
            DebugHelpers.WriteLine("_Parameters -> "+_Parameters);
            DebugHelpers.WriteLine("_parametersBackup -> " + _parametersBackup);
            DebugHelpers.WriteLine("_ViewModel -> " + _ViewModel);
            Console.WriteLine("\n");

            // Se il ViewModel è stato passato da PushAsync, usiamolo
            if (_parametersBackup == null && _Parameters != null)
            {
                _parametersBackup = _Parameters;

                _navigationParameters = _Parameters?.ToNavParameters();

                BindingContext = _ViewModel;

                if (this is IInitialize initialize)
                    initialize.Initialize(_navigationParameters);

                if (BindingContext is IInitialize vm)
                    vm.Initialize(_navigationParameters);

                OnAppearing();

            }
        }

        /// <summary>
        /// Simula il comportamento di OnDisappearing quando la pagina viene rimossa o chiusa.
        /// </summary>
        public override void Dispose()
        {
            DebugHelpers.WriteLine("Dispose -> "+this);

            OnDisappearing();
        }

        #region MAUI
        protected override void OnAppearing()
        {
            base.OnAppearing();

            OnNavigatedTo();

            if (this is IPageLifecycleAware lifecycleAware)
                lifecycleAware.OnAppearing();

            if (BindingContext is IPageLifecycleAware vm1)
                vm1.OnAppearing();
        }

        void OnNavigatedTo()
        {
            if (this is INavigationAware navigationAware)
                navigationAware.OnNavigatedTo(_navigationParameters);

            if (BindingContext is INavigationAware vm)
                vm.OnNavigatedTo(_navigationParameters);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            //if (this is INavigationAware navigationAware)
            //    navigationAware.OnNavigatedFrom(_navigationParameters);

            //if (BindingContext is INavigationAware vm)
            //    vm.OnNavigatedFrom(_navigationParameters);

            if (this is IPageLifecycleAware lifecycleAware)
                lifecycleAware.OnDisappearing();

            if (BindingContext is IPageLifecycleAware vm1)
                vm1.OnDisappearing();
        }
        #endregion
    }

}

