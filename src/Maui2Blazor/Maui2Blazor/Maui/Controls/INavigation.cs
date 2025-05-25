namespace Maui2Blazor.Maui.Controls
{
    public interface INavigation
    {
        /// <summary>
        /// Naviga verso una nuova pagina (rappresentata qui genericamente).
        /// </summary>
        Task NavigateToAsync(object page);

        /// <summary>
        /// Torna indietro nella pila di navigazione.
        /// </summary>
        Task GoBackAsync();
    }
}

