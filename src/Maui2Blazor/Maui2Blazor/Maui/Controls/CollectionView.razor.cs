using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class CollectionView : ItemsView
    {
        // **SELEZIONE**
        [Parameter] public SelectionMode SelectionMode { get; set; } = SelectionMode.None;
        [Parameter] public object SelectedItem { get; set; }
        [Parameter] public EventCallback<object> OnSelectionChanged { get; set; }

        // **HEADER & FOOTER**
        [Parameter] public RenderFragment Header { get; set; }
        [Parameter] public RenderFragment Footer { get; set; }
        [Parameter] public RenderFragment HeaderComponent { get; set; } // <CollectionView.Header>
        [Parameter] public RenderFragment FooterComponent { get; set; } // <CollectionView.Footer>

        // **GESTIONE ELEMENTI**
        [Parameter] public RenderFragment EmptyView { get; set; }
        [Parameter] public bool IsGrouped { get; set; } = false;
        [Parameter] public RenderFragment<object> GroupHeaderTemplate { get; set; }
        [Parameter] public RenderFragment<object> GroupFooterTemplate { get; set; }

        // **TEMPLATE & LAYOUT**
        [Parameter] public RenderFragment ItemTemplateComponent { get; set; } // <CollectionView.ItemTemplate>
        [Parameter] public DataTemplateSelector ItemTemplateSelector { get; set; }

        // **SUPPORTO PER `GridItemsLayout` E `LinearItemsLayout`**
        [Parameter] public ItemsLayoutType ItemsLayout { get; set; } = ItemsLayoutType.Linear;
        [Parameter] public int GridSpan { get; set; } = 1; // Numero di colonne nella griglia
        [Parameter] public RenderFragment ItemsLayoutComponent { get; set; } // <CollectionView.ItemsLayout>

        private HashSet<object> SelectedItems { get; set; } = new();

        /// <summary>
        /// Determina il template corretto per ogni elemento.
        /// </summary>
        protected override RenderFragment<object> GetItemTemplate(object item)
        {

            if (ItemTemplateSelector != null)
                return ItemTemplateSelector.SelectTemplate(item);

            if (ItemTemplateComponent != null)
                return item => builder => ItemTemplateComponent?.Invoke(builder);

            return ItemTemplate ?? (item => builder => ItemTemplate.Invoke(builder));
        }

        /// <summary>
        /// Verifica se la CollectionView è vuota.
        /// </summary>
        private bool IsEmpty => ItemsSource == null || !ItemsSource.Cast<object>().Any();

        /// <summary>
        /// Gestisce la selezione di un elemento.
        /// </summary>
        private async Task HandleSelectionAsync(object item)
        {
            if (SelectionMode == SelectionMode.None) return;

            if (SelectionMode == SelectionMode.Single)
            {
                SelectedItem = item;
                await OnSelectionChanged.InvokeAsync(item);
            }
            else if (SelectionMode == SelectionMode.Multiple)
            {
                if (SelectedItems.Contains(item))
                    SelectedItems.Remove(item);
                else
                    SelectedItems.Add(item);

                await OnSelectionChanged.InvokeAsync(SelectedItems);
            }

            StateHasChanged();
        }

        /// <summary>
        /// Metodo per ottenere lo stile CSS del layout in base all'orientamento e al tipo di layout.
        /// </summary>
        protected override string GetCombinedStyle()
        {
            var style = base.GetCombinedStyle();

            style += ItemsLayout switch
            {
                ItemsLayoutType.Linear => "display: flex; flex-direction: column; overflow-y: auto; height: 100%;",
                ItemsLayoutType.Horizontal => "display: flex; flex-direction: row; overflow-x: auto;",
                ItemsLayoutType.Grid => $"display: grid; grid-template-columns: repeat({GridSpan}, 1fr); gap: 10px;",
                _ => "display: flex; flex-direction: column;"
            };
            return style;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            StateHasChanged();
        }
    }

    public enum ItemsLayoutType
    {
        Linear,
        Horizontal,
        Grid
    }
}
