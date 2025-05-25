using Maui2Blazor.Maui.Views;

namespace Maui2BlazorSamples.Views.HelloWorld
{
    public partial class HelloWorldPage : ContentPageBase
    {
		public int Count { get; private set; }

		public HelloWorldPage()
		{
			Title = "Hello World";
		}

		public void IncreseCount()
		{
			Count++;
        }

    }
}

