using System.Runtime.CompilerServices;

namespace Maui2Blazor.Utils
{
    public static class DebugHelpers
    {
        public static void WriteLine(object obj,
                           [CallerFilePath] string filePath = "",
                           [CallerLineNumber] int lineNumber = 0)
        {
            var fileName = Path.GetFileName(filePath);
            Console.WriteLine($"[{fileName}:{lineNumber}] {obj?.ToString()}");
        }
    }
}

