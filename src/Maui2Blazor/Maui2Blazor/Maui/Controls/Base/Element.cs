namespace Maui2Blazor.Maui.Controls
{

    public abstract class Element : BindableObject
    {
        /// <summary>
        /// Rappresenta l'elemento genitore nell'albero logico.
        /// </summary>
        public Element Parent { get; private set; }

        /// <summary>
        /// Raccolta immutabile dei figli logici.
        /// </summary>
        private readonly List<Element> _logicalChildren = new List<Element>();
        public IEnumerable<Element> LogicalChildren => _logicalChildren.AsReadOnly();

        /// <summary>
        /// Aggiunge un elemento figlio alla raccolta dei LogicalChildren e imposta il suo Parent.
        /// </summary>
        /// <param name="child">Il figlio da aggiungere.</param>
        public void AddLogicalChild(Element child)
        {
            if (child == null)
                return;

            if (!_logicalChildren.Contains(child))
            {
                _logicalChildren.Add(child);
                child.SetParent(this);
                OnChildAdded(child);
            }
        }

        /// <summary>
        /// Rimuove un elemento figlio dalla raccolta dei LogicalChildren e ne azzera il Parent.
        /// </summary>
        /// <param name="child">Il figlio da rimuovere.</param>
        public void RemoveLogicalChild(Element child)
        {
            if (child == null)
                return;

            if (_logicalChildren.Contains(child))
            {
                _logicalChildren.Remove(child);
                child.SetParent(null);
                OnChildRemoved(child);
            }
        }

        /// <summary>
        /// Metodo virtuale invocato quando viene aggiunto un figlio.
        /// Può essere overridato nelle classi derivate per eseguire logica aggiuntiva.
        /// </summary>
        /// <param name="child">Il figlio aggiunto.</param>
        protected virtual void OnChildAdded(Element child)
        {
            // Implementare logica specifica se necessario.
        }

        /// <summary>
        /// Metodo virtuale invocato quando viene rimosso un figlio.
        /// Può essere overridato nelle classi derivate per eseguire logica aggiuntiva.
        /// </summary>
        /// <param name="child">Il figlio rimosso.</param>
        protected virtual void OnChildRemoved(Element child)
        {
            // Implementare logica specifica se necessario.
        }

        /// <summary>
        /// Imposta il Parent dell'elemento.
        /// È interno in modo che venga gestito dalle operazioni Add/Remove dei figli.
        /// </summary>
        /// <param name="parent">Il nuovo genitore oppure null se rimosso.</param>
        internal void SetParent(Element parent)
        {
            Parent = parent;
            OnParentChanged();
        }

        /// <summary>
        /// Metodo virtuale invocato quando il Parent cambia.
        /// Può essere overridato per reagire al cambio di contesto.
        /// </summary>
        protected virtual void OnParentChanged()
        {
            // Implementare logica specifica se necessario.
        }
    }

}

