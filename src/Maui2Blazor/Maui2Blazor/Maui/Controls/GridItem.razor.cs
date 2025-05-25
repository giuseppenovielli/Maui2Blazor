using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class GridItem : ComponentBase
    {
        /// <summary>
        /// Il contenuto dell'elemento.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Specifica la riga (0-based) in cui posizionare l'elemento.
        /// </summary>
        [Parameter] public int GridRow { get; set; } = 0;

        /// <summary>
        /// Specifica la colonna (0-based) in cui posizionare l'elemento.
        /// </summary>
        [Parameter] public int GridColumn { get; set; } = 0;

        /// <summary>
        /// Specifica quante righe deve occupare l'elemento.
        /// </summary>
        [Parameter] public int GridRowSpan { get; set; } = 1;

        /// <summary>
        /// Specifica quante colonne deve occupare l'elemento.
        /// </summary>
        [Parameter] public int GridColumnSpan { get; set; } = 1;

        /// <summary>
        /// Calcola lo stile CSS per posizionare l'elemento nella griglia.
        /// </summary>
        protected string GridItemStyle =>
            $"grid-row: {GridRow + 1} / span {GridRowSpan}; grid-column: {GridColumn + 1} / span {GridColumnSpan};";
    }
}

