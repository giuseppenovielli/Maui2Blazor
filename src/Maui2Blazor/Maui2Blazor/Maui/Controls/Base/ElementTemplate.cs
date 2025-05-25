using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{ 
    public abstract class ElementTemplate : Object
    {
        /// <summary>
        /// Template generico per un elemento.
        /// </summary>
        public RenderFragment<object> Template { get; }

        /// <summary>
        /// Inizializza un nuovo template con un `RenderFragment<object>`.
        /// </summary>
        public ElementTemplate(RenderFragment<object> template)
        {
            Template = template;
        }

        /// <summary>
        /// Crea un'istanza del template con il dato di binding specificato.
        /// </summary>
        public RenderFragment CreateContent(object bindingContext)
        {
            return Template?.Invoke(bindingContext);
        }
    }
}

