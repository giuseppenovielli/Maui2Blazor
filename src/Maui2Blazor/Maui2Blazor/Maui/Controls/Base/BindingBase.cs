namespace Maui2Blazor.Maui.Controls
{
    public abstract class BindingBase : Object
    {
        /// <summary>
        /// Il componente associato al binding.
        /// </summary>
        public object AssociatedObject { get; private set; }

        /// <summary>
        /// Associa il binding a un oggetto.
        /// </summary>
        public void Attach(object target)
        {
            AssociatedObject = target;
            OnAttached();
        }

        /// <summary>
        /// Rimuove l'associazione.
        /// </summary>
        public void Detach()
        {
            OnDetaching();
            AssociatedObject = null;
        }

        /// <summary>
        /// Metodo chiamato quando il binding viene attaccato.
        /// </summary>
        protected virtual void OnAttached() { }

        /// <summary>
        /// Metodo chiamato quando il binding viene rimosso.
        /// </summary>
        protected virtual void OnDetaching() { }
    }

    public enum BindingMode
    {
        OneWay,
        TwoWay,
        OneTime
    }

}
