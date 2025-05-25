using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;


namespace Maui2Blazor.Maui.Controls
{

    public partial class RefreshView : ContentView
    {
        /// <summary>
        /// Indica se il contenuto è in fase di aggiornamento.
        /// </summary>
        [Parameter] public bool IsRefreshing { get; set; }

        /// <summary>
        /// Comando eseguito quando si attiva il refresh.
        /// </summary>
        [Parameter] public EventCallback OnRefresh { get; set; }

        private bool _isDragging = false;
        private int _dragStartY = 0;

        /// <summary>
        /// Attiva manualmente il refresh.
        /// </summary>
        public async Task RefreshAsync()
        {
            IsRefreshing = true;
            StateHasChanged();

            await OnRefresh.InvokeAsync();

            IsRefreshing = false;
            StateHasChanged();
        }

        /// <summary>
        /// Inizio trascinamento.
        /// </summary>
        private void StartDrag(PointerEventArgs e)
        {
            _isDragging = true;
            _dragStartY = (int)e.ClientY;
        }

        /// <summary>
        /// Rileva il rilascio e attiva il refresh se il trascinamento è sufficiente.
        /// </summary>
        private async Task EndDrag(PointerEventArgs e)
        {
            if (_isDragging)
            {
                int dragEndY = (int)e.ClientY;
                int dragDistance = dragEndY - _dragStartY;

                if (dragDistance > 50) // Se l'utente ha trascinato verso il basso per almeno 50px
                {
                    await RefreshAsync();
                }

                _isDragging = false;
            }
        }
    }


}

