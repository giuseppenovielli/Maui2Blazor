using System.ComponentModel;
using System.Reflection;
using Maui2Blazor.Utils;
using Microsoft.AspNetCore.Components;

namespace Maui2Blazor.Maui.Controls
{
    public partial class DataTrigger : TriggerBase<BindableObject>
    {
        /// <summary>
        /// Nome della proprietà su cui si basa il trigger.
        /// </summary>
        [Parameter] public object BindingProperty { get; set; } = new object();

        /// <summary>
        /// Valore che attiva il trigger.
        /// </summary>
        [Parameter] public object Value { get; set; }

        /// <summary>
        /// Lista dei Setter associati al trigger.
        /// </summary>
        [Parameter] public List<Setter> Setters { get; set; } = new();


        /// <summary>
        /// Metodo chiamato quando il trigger viene attivato.
        /// </summary>
        void OnTriggered()
        {
            if (AssociatedObject == null)
                return;

            DebugHelpers.WriteLine($"\n🔹 DataTrigger attivato: {BindingProperty} == {Value}");

            foreach (var setter in Setters)
            {
                SetPropertyValue(AssociatedObject, setter.Property, setter.Value);
            }

            PropertyChangedNotificationInterceptor.EnableIsPropertyChangedSuppressed();
            AssociatedObject.InvokeStateHasChanged();
        }

        protected override void OnAttached()
        {
            if (AssociatedObject == null)
                return;

            //DebugHelpers.WriteLine("🔹 DataTrigger");
            //DebugHelpers.WriteLine(BindingProperty);
            //DebugHelpers.WriteLine(Value);

            // Ottenere il valore iniziale
            //_currentValue = GetPropertyValue(AssociatedObject, BindingProperty);

            // Controllare se il trigger deve essere attivato subito
            if (IsConditionMet(BindingProperty))
            {
                OnTriggered();
            }

            //Sottoscriversi agli aggiornamenti della proprietà
            if (AssociatedObject is BindableObject bindable)
            {
                bindable.PropertyChanged += OnPropertyChangedTrigger;
            }
        }

        protected override void OnDetaching()
        {
            if (AssociatedObject is BindableObject bindable)
            {
                bindable.PropertyChanged -= OnPropertyChangedTrigger;
            }
        }

        void OnPropertyChangedTrigger(object sender, PropertyChangedEventArgs e)
        {
            if (IsConditionMet(BindingProperty))
            {
                OnTriggered();
            }
        }

        private bool IsConditionMet(object newValue)
        {
            return newValue != null && newValue.Equals(Value);
        }

        private object GetPropertyValue(object obj, string propertyName)
        {
            var prop = obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            return prop?.GetValue(obj);
        }

        private void SetPropertyValue(object obj, string propertyName, object value)
        {
            DebugHelpers.WriteLine($"🔹 SetPropertyValue");
            DebugHelpers.WriteLine(propertyName);
            DebugHelpers.WriteLine(value);

            var prop = obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
            {
                value ??= default;

                prop.SetValue(obj, value);
            }
        }

        /// <summary>
        /// Aggiunge un nuovo Setter agli stili definiti.
        /// </summary>
        public void AddSetter(string property, object value)
        {
            Setters.Add(new Setter { Property = property, Value = value });
        }
    }
}
