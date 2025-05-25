namespace Maui2Blazor.Maui.Extensions
{
    public static class StackExtensions
    {
        public static T SafePeek<T>(this Stack<T> stack)
        {
            return stack.Count > 0 ? stack.Peek() : default;
        }
    }
}

