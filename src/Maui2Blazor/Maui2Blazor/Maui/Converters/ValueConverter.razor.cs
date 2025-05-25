using System.ComponentModel;
using System.Globalization;
using Maui2Blazor.Maui.Controls;
using Maui2Blazor.Utils;
using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Converters
{
    public partial class ValueConverter : TriggerBase<BindableObject>
    {
        [Parameter] public object Binding { get; set; }
        [Parameter] public IValueConverter Converter { get; set; }
        [Parameter] public string TargetProperty { get; set; }

        protected override void OnAttached()
        {
            OnTriggered();

            //Sottoscriversi agli aggiornamenti della proprietà
            if (AssociatedObject is BindableObject bindable)
            {
                bindable.PropertyChanged += OnPropertyChangedTrigger;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            if (AssociatedObject is BindableObject bindable)
            {
                bindable.PropertyChanged -= OnPropertyChangedTrigger;
            }
        }

        void OnPropertyChangedTrigger(object sender, PropertyChangedEventArgs e)
        {
            OnTriggered();

        }

        private void OnTriggered()
        {
            DebugHelpers.WriteLine("\n🔹 ValueConverter");
            DebugHelpers.WriteLine(AssociatedObject);
            DebugHelpers.WriteLine(TargetProperty);
            DebugHelpers.WriteLine(Converter);
            DebugHelpers.WriteLine(Binding);

            if (string.IsNullOrEmpty(TargetProperty) || Converter == null)
                return;

            var converted = Converter.Convert(Binding, typeof(object), null, CultureInfo.InvariantCulture);
            var prop = AssociatedObject.GetType().GetProperty(TargetProperty);

            if (prop != null && prop.CanWrite)
            {
                DebugHelpers.WriteLine("Convertito!");
                DebugHelpers.WriteLine($"{TargetProperty} -> {converted}");

                prop.SetValue(AssociatedObject, converted);

                if (AssociatedObject is DataTrigger dataTrigger)
                {
                    dataTrigger.Attach();
                    return;
                }

                PropertyChangedNotificationInterceptor.EnableIsPropertyChangedSuppressed();
                AssociatedObject.InvokeStateHasChanged();
            }
        }
    }
}
