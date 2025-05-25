using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public abstract class TriggerBase<T> : BindableObject
        where T : BindableObject
    {
        /// <summary>
        /// Contenuto figlio dell'elemento.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Componente al quale il trigger è associato.
        /// </summary>
        [CascadingParameter]
        public T AssociatedObject { get; set; }

        public TriggerBase()
        {
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender)
                Attach();

        }


        /// <summary>
        /// Associa il trigger a un componente BindableObject.
        /// </summary>
        public void Attach()
        {
            if (AssociatedObject == null)
                return;

            if (AssociatedObject.GetType() == typeof(NavigationPage))
                return;

            OnAttached();
        }


        /// <summary>
        /// Rimuove l'associazione con il BindableObject.
        /// </summary>
        public void Detach()
        {
            OnDetaching();
            AssociatedObject = null;
        }

        /// <summary>
        /// Metodo chiamato quando il trigger viene attaccato.
        /// </summary>
        protected abstract void OnAttached();

        /// <summary>
        /// Metodo chiamato quando il trigger viene rimosso.
        /// </summary>
        protected virtual void OnDetaching() { }

        public override void Dispose()
        {
            Detach();
        }
    }
}

