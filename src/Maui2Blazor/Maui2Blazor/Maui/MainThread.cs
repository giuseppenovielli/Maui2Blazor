namespace Maui2Blazor
{
    public static class MainThread
    {
        public static async void BeginInvokeOnMainThread(Func<Task> action)
        {
            var syncContext = SynchronizationContext.Current;
            if (syncContext != null)
            {
                var tcs = new TaskCompletionSource<bool>();
                syncContext.Post(async _ =>
                {
                    try
                    {
                        await action();
                        tcs.SetResult(true);
                    }
                    catch (Exception ex)
                    {
                        tcs.SetException(ex);
                    }
                }, null);

                await tcs.Task;
            }
            else
            {
                await action();
            }
        }
    }
}

