using Maui2Blazor.Maui.Controls;
using Maui2Blazor.Maui.Extensions;
using Maui2Blazor.Maui.Mopups;
using Maui2Blazor.Maui.Prism;
using Maui2Blazor.Maui.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Maui2Blazor
{
    public static class Maui2BlazorApp
    {
        public static IServiceProvider IOCContainer { get; private set; }
        public static NavigationPage NavigationPage { get; set; }

        public static event Action<Dictionary<Type, Type>> OnRegisterPageToViewModelMap;
        public static event Action<INavigationService> OnNavigateToFirstPage;

        public static void ConfigureBuilder(WebAssemblyHostBuilder builder)
        {
            // Configura i servizi dell'app
            ConfigureServices(builder.Services);
        }

        public static void ConfigureHost(WebAssemblyHost host)
        {
            // Salva il ServiceProvider globale
            IOCContainer = host.Services;

            var navigationPageService = IOCContainer.Resolve<INavigationPageService>();

            navigationPageService.OnRegisterPageToViewModelMap += (Dictionary<Type, Type> obj) =>
            {
                OnRegisterPageToViewModelMap?.Invoke(obj);
            };

            if (navigationPageService is NavigationPageService navPageService)
                navPageService.RegisterPageToViewModelMap();
        }

        public static void NavigateToFirstPage(INavigationService service)
        {
            OnNavigateToFirstPage?.Invoke(service);
        }

        static void ConfigureServices(IServiceCollection services)
        {
            #region Maui

            #region Prism
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IContainerProvider, ContainerProvider>();
            #endregion

            #region Mopups
            services.AddSingleton<IPopupNavigation, PopupNavigation>();
            #endregion

            #region DisplayDialog
            services.AddSingleton<IDisplayDialogService, DisplayDialogService>();
            #endregion

            //Navigation
            services.AddSingleton<INavigationPageService, NavigationPageService>();
            #endregion
        }

        
    }
}

