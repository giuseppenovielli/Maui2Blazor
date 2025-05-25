using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public abstract class Layout : View
    {
        /// <summary>
        /// Collezione di figli aggiunti programmaticamente.
        /// </summary>
        public IList<VisualElement> Children { get; } = new List<VisualElement>();


        /// <summary>
        /// Helper per convertire un VisualElement figlio in un RenderFragment.
        /// </summary>
        protected RenderFragment RenderChild(VisualElement child) => builder =>
        {
            builder.OpenComponent(0, child.GetType());
            builder.CloseComponent();
        };
    }

}

