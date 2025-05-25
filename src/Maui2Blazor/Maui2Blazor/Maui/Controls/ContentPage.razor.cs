using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class ContentPage : TemplatedPage
    {
        /// <summary>
        /// Indica se la pagina deve avere la barra di navigazione.
        /// </summary>
        [Parameter] public bool HasNavigationBar { get; set; } = true;

        /// <summary>
        /// Colore di sfondo della barra di navigazione.
        /// </summary>
        [Parameter] public string BarBackgroundColor { get; set; } = "#007BFF";

        /// <summary>
        /// Colore del testo della barra di navigazione.
        /// </summary>
        [Parameter] public string BarTextColor { get; set; } = "white";


        /// <summary>
        /// Pagina da non aggiungere allo stack perché è di tipo Base.
        /// </summary>
        [Parameter] public bool IsBasePage { get; set; }

        /// <summary>
        /// Quando ContentPage viene inizializzata, notifica la NavigationPage del titolo.
        /// </summary>
        [CascadingParameter] public NavigationPage NavigationPage { get; set; }


        protected override void OnInitialized()
        {
            base.OnInitialized();

            if(!IsBasePage)
                NavigationPage?._navigationContentPageStack.Push(this);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (NavigationPage == null)
                return;

            var navContentPageStack = NavigationPage._navigationContentPageStack;
            if (!navContentPageStack.Contains(this) && !this.IsBasePage)
                navContentPageStack.Push(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            NavigationPage?.SetPageTitle(Title);
        }

        #region Reload UI
        private readonly Queue<Func<Task>> _afterRenderCallbacks = new();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            while (_afterRenderCallbacks.TryDequeue(out var callback))
            {
                await callback();
            }
        }

        
        void EnqueuePostRenderCallback(Func<Task> callback)
        {
            _afterRenderCallbacks.Enqueue(callback);
        }


        //public Task InvokeSafeStateHasChanged()
        //{
        //    _suppressPropertyChanged = true;

        //    return EnqueuePostRenderCallback(async () =>
        //    {
        //        _suppressPropertyChanged = false;
        //    });
        //}

        bool _isRenderQueued = false;
        readonly TimeSpan DebounceDelay = TimeSpan.FromMilliseconds(50);
        public void InvokeSafeStateHasChanged()
        {
            if (_isRenderQueued)
                return;

            _isRenderQueued = true;

            _ = Task.Delay(DebounceDelay).ContinueWith(async _ =>
            {
                await InvokeAsync(StateHasChanged);
                _isRenderQueued = false;
            });
        }


        
        #endregion
    }
}

