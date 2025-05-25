using Maui2Blazor.Maui.Prism;

namespace Maui2Blazor.Maui.Extensions
{
    public static class DictionaryExtensions
	{
        public static NavigationParameters ToNavParameters(this Dictionary<string, object> parameters)
        {
            if (parameters == null)
                return null;

            var navParameters = new NavigationParameters();
            foreach (var key in parameters.Keys)
            {
                navParameters.Add(key, parameters[key]);
            }

            return navParameters;
        }
    }
}

