namespace Maui2Blazor.Maui.Prism
{
    // Interfaccia per la gestione della distruzione (equivalente a IDestructible)
    public interface IDestructible
    {
        void Destroy();
    }

    // Interfaccia per gestire eventi del ciclo di vita dell'app (equivalente a IApplicationLifecycleAware)
    public interface IApplicationLifecycleAware
    {
        void OnResume();
        void OnSleep();
    }

    // Interfaccia per il ciclo di vita della pagina (equivalente a IPageLifecycleAware)
    public interface IPageLifecycleAware
    {
        void OnAppearing();
        void OnDisappearing();
    }

    // Interfaccia per la gestione della navigazione (equivalente a INavigationAware)
    public interface INavigationAware
    {
        void OnNavigatedTo(INavigationParameters parameters);
        void OnNavigatedFrom(INavigationParameters parameters);
    }

    // Interfaccia per inizializzare un ViewModel con parametri (equivalente a IInitialize)
    public interface IInitialize
    {
        void Initialize(INavigationParameters parameters);
    }

    // Interfaccia per gestire opzioni della pagina di navigazione (equivalente a INavigationPageOptions)
    public interface INavigationPageOptions
    {
        bool ClearNavigationStackOnNavigation { get; }
    }
}
