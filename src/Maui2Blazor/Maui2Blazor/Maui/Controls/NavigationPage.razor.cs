using System.Reflection;
using Maui2Blazor.Maui.Extensions;
using Maui2Blazor.Maui.Prism;
using Maui2Blazor.Utils;
using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class NavigationPage : Page
    {
        private readonly Stack<RenderFragment> _navigationStack = new();
        public readonly Stack<ContentPage> _navigationContentPageStack = new();

        /// <summary>
        /// Pagina attualmente visualizzata.
        /// </summary>
        public RenderFragment CurrentPage => _navigationStack.SafePeek();

        /// <summary>
        /// Pagina corrente tipo ContentPage (impostato dalla ContentPage).
        /// </summary>
        public ContentPage CurrentContentPage => _navigationContentPageStack.SafePeek();

        /// <summary>
        /// Titolo della pagina corrente (impostato dalla ContentPage).
        /// </summary>
        public string CurrentPageTitle { get; private set; } = string.Empty;

        /// <summary>
        /// Colore di sfondo della toolbar.
        /// </summary>
        [Parameter]
        public string BarBackgroundColor { get; set; } = "#007BFF";

        /// <summary>
        /// Colore del testo della toolbar.
        /// </summary>
        [Parameter]
        public string BarTextColor { get; set; } = "white";

        /// <summary>
        /// Indica se la barra di navigazione deve essere visibile.
        /// </summary>
        [Parameter]
        public bool HasNavigationBar { get; set; } = true;

        /// <summary>
        /// Indica se il pulsante Back deve essere visibile.
        /// </summary>
        [Parameter]
        public bool HasBackButton { get; set; } = true;


        /// <summary>
        /// Indica se e' in corso il push di una nuova pagina
        /// </summary>
        public bool IsPushingPage { get; set; }

        protected override void OnInitialized()
        {
            //var navPageService = AppStartup.IOCContainer.Resolve<INavigationPageService>();
            //navPageService.RegisterNavigationPage(this);
            Maui2BlazorApp.NavigationPage = this;

            if (ChildContent != null)
                _navigationStack.Push(ChildContent);

        }

        /// <summary>
        /// Imposta il titolo della pagina corrente.
        /// </summary>
        public void SetPageTitle(string title)
        {
            if (CurrentPageTitle != title)
            {
                CurrentPageTitle = title;
                StateHasChanged();
            }
        }

        /// <summary>
        /// Aggiunge una nuova pagina alla pila di navigazione.
        /// </summary>
        public void PushPage<TPage>(Dictionary<string, object> parameters = null) where TPage : Page
        {
            PushAsync(typeof(TPage), parameters);
        }


        /// <summary>
        /// Aggiunge una nuova pagina alla pila di navigazione accettando il tipo della pagina come parametro.
        /// </summary>
        public void PushAsync(Type pageType, Dictionary<string, object> parameters = null, object viewModel = null)
        {
            if (!typeof(Page).IsAssignableFrom(pageType))
                throw new InvalidOperationException($"Il tipo {pageType.FullName} non è una pagina valida.");

            parameters ??= new Dictionary<string, object>();

            //StartTimerInThread();

            OnNavigatedFrom(parameters);

            _navigationStack.Push(builder =>
            {
                builder.OpenComponent(0, pageType);

                // Passiamo il ViewModel
                if (viewModel != null)
                {
                    builder.AddAttribute(1, "_ViewModel", viewModel);
                }
                    

                builder.AddAttribute(2, "_Parameters", parameters);

                builder.CloseComponent();
            });

            DebugHelpers.WriteLine("\nNavigationPage PushAsync");
            DebugHelpers.WriteLine(pageType);
            DebugHelpers.WriteLine(viewModel);
            DebugHelpers.WriteLine(parameters);
            DebugHelpers.WriteLine(_navigationContentPageStack.Count);

            PropertyChangedNotificationInterceptor.EnableIsPropertyChangedSuppressed();
            InvokeStateHasChanged();
        }

        public void StartTimerInThread()
        {
            // Avvia il timer in un thread secondario
            Task.Run(async () =>
            {
                await Task.Delay(1000); // aspetta 3 secondi

                // Notifica Blazor per aggiornare la UI (serve perché siamo su un altro thread)
                await InvokeAsync(StateHasChanged);
            });
        }

        public void PopBackPage()
        {
            PopPage();
        }

        /// <summary>
        /// Rimuove la pagina corrente (se ce ne sono almeno due) con parametri
        /// </summary>
        public void PopPage(Dictionary<string, object> parameters = null)
        {
            if (_navigationStack.Count <= 1)
                return;

           // StartTimerInThread();

            parameters ??= new Dictionary<string, object>();

            OnNavigatedFrom(parameters);

            _navigationStack.Pop();
            _navigationContentPageStack.Pop();

            OnNavigatedTo(parameters);

            CurrentPageTitle = CurrentContentPage?.Title;

            DebugHelpers.WriteLine("\nNavigationPage PopAsync parameters");
            DebugHelpers.WriteLine(parameters);
            DebugHelpers.WriteLine(CurrentContentPage);
            DebugHelpers.WriteLine(_navigationStack.Count);

            PropertyChangedNotificationInterceptor.EnableIsPropertyChangedSuppressed();
            InvokeStateHasChanged();
        }

        void OnNavigatedFrom(Dictionary<string, object> parameters)
        {
            var navParams = parameters.ToNavParameters();

            if (CurrentContentPage is INavigationAware navigationAware)
                navigationAware.OnNavigatedFrom(navParams);

            if (CurrentContentPage?.BindingContext is INavigationAware vm)
                vm.OnNavigatedFrom(navParams);
        }

        void OnNavigatedTo(Dictionary<string, object> parameters)
        {
            var navParams = parameters.ToNavParameters();

             if (CurrentContentPage is INavigationAware navigationAware)
                navigationAware.OnNavigatedTo(navParams);

            if (CurrentContentPage?.BindingContext is INavigationAware vm)
                vm.OnNavigatedTo(navParams);
        }

        public static int CountBindableProperties(object instance)
        {
            var type = instance.GetType();
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var propertyNames = new List<string>();

            foreach (var prop in properties)
            {
                propertyNames.Add(prop.Name);
            }
            return propertyNames.Count;
        }


        
    }

}
