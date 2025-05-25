using System.ComponentModel;
using Maui2Blazor.Maui.Interfaces;

namespace Maui2Blazor.Maui.Models
{
    public class ItemBase : INotifyPropertyChangedExtended
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ItemBase()
		{
		}

        public void OnPropertyChanged(object target, string propertyName)
        {
            PropertyChanged?.Invoke(target, new PropertyChangedEventArgs(propertyName));
        }
    }
}

