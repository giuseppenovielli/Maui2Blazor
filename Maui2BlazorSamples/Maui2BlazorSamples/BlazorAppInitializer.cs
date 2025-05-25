using Maui2Blazor;
using Maui2BlazorSamples.Pages;
using Maui2BlazorSamples.ViewModels;
using Maui2BlazorSamples.Views.CollectionView;
using Maui2BlazorSamples.Views.HelloWorld;
using Maui2BlazorSamples.Views.Main;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Maui2BlazorSamples
{
    public static class BlazorAppInitializer
    {
        public static async Task RunAsync(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            ConfigureBuilder(builder);

            // Costruisci l'applicazione
            var app = builder.Build();
            ConfigureHost(app);

            // Avvia l'app
            await app.RunAsync();
        }

        #region Builder
        static void ConfigureBuilder(WebAssemblyHostBuilder builder)
        {
            Maui2BlazorApp.ConfigureBuilder(builder);
            ConfigureRootComponents(builder);
            ConfigureServices(builder.Services);
        }

        static void ConfigureRootComponents(WebAssemblyHostBuilder builder)
        {
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
        }

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<StartPage>();

            services.AddTransient<MainPage>();
            services.AddTransient<MainPageViewModel>();

            services.AddTransient<CollectionViewPage>();
            services.AddTransient<CollectionViewPageViewModel>();

            services.AddTransient<HelloWorldPage>();

        }
        #endregion

        #region Host
        static void ConfigureHost(WebAssemblyHost app)
        {
            Maui2BlazorApp.OnRegisterPageToViewModelMap += (Dictionary<Type, Type> obj) =>
            {
                obj.Add(typeof(MainPage), typeof(MainPageViewModel));
                obj.Add(typeof(CollectionViewPage), typeof(CollectionViewPageViewModel));

            };

            Maui2BlazorApp.OnNavigateToFirstPage += (Maui2Blazor.Maui.Prism.INavigationService service) =>
            {
                service.NavigateAsync(nameof(MainPage));
            };

            Maui2BlazorApp.ConfigureHost(app);
            
        }
        #endregion
    }
}
