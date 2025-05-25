using System.Windows.Input;
using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class ListView : ItemsView
    {
        // --- PROPRIETÀ DI BINDING E DATI ---
        [Parameter] public RenderFragment Header { get; set; }
        [Parameter] public RenderFragment Footer { get; set; }
        [Parameter] public RenderFragment EmptyView { get; set; }

        // --- SELEZIONE ---
        [Parameter] public SelectionMode SelectionMode { get; set; } = SelectionMode.Single;
        [Parameter] public object SelectedItem { get; set; }
        [Parameter] public EventCallback<object> OnSelectionChanged { get; set; }
        private HashSet<object> SelectedItems { get; set; } = new();

        // --- ASPETTI VISIVI ---
        [Parameter] public int RowHeight { get; set; } = 50;
        [Parameter] public bool HasUnevenRows { get; set; } = false;
        [Parameter] public SeparatorVisibility SeparatorVisibility { get; set; } = SeparatorVisibility.Default;
        [Parameter] public string SeparatorColor { get; set; } = "#CCCCCC";

        // --- PULL-TO-REFRESH ---
        [Parameter] public bool IsRefreshing { get; set; } = false;
        [Parameter] public ICommand RefreshCommand { get; set; }
        [Parameter] public EventCallback OnRefresh { get; set; }

        // --- PROPRIETÀ INTERNE ---
        protected bool IsEmpty => ItemsSource == null || !ItemsSource.Cast<object>().Any();

        /// <summary>
        /// Restituisce lo stile CSS della ListView.
        /// </summary>
        protected override string GetCombinedStyle()
        {
            var style = base.GetCombinedStyle();
            style += "display: flex; flex-direction: column; overflow-y: auto; height: 100%;";
            return style;
        }
            

        /// <summary>
        /// Restituisce lo stile del container degli elementi, in base a RowHeight e HasUnevenRows.
        /// </summary>
        protected string GetItemContainerStyle() =>
            HasUnevenRows ? "display: block;" : $"height: {RowHeight}px; display: flex; align-items: center;";

        /// <summary>
        /// Restituisce il template da utilizzare per ciascun elemento.
        /// </summary>
        protected override RenderFragment<object> GetItemTemplate(object item) => ItemTemplate;

        // --- METODI DI GESTIONE ---

        /// <summary>
        /// Gestisce la selezione di un elemento.
        /// </summary>
        protected async Task HandleSelectionAsync(object item)
        {
            if (SelectionMode == SelectionMode.None)
                return;

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
        /// Gestisce il refresh della lista.
        /// </summary>
        protected async Task RefreshDataAsync()
        {
            if (RefreshCommand != null && RefreshCommand.CanExecute(null))
            {
                RefreshCommand.Execute(null);
            }
            await OnRefresh.InvokeAsync();
            IsRefreshing = false;
            StateHasChanged();
        }
    }
}
