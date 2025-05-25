using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maui2Blazor.Maui.Interfaces
{
    public interface INotifyPropertyChangedExtended : INotifyPropertyChanged
    {
        void OnPropertyChanged(object sender, [CallerMemberName] string propertyName = null);

    }
}

