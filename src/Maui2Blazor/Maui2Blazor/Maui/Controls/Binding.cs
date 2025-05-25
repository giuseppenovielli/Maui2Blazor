using System.ComponentModel;
using System.Reflection;

namespace Maui2Blazor.Maui.Controls
{
    public class Binding : BindingBase
    {
        private object _source;
        private object _target;
        private PropertyInfo _sourceProperty;
        private PropertyInfo _targetProperty;

        /// <summary>
        /// Modalità di binding.
        /// </summary>
        public BindingMode Mode { get; set; } = BindingMode.OneWay;

        /// <summary>
        /// Proprietà di origine per il binding.
        /// </summary>
        public string SourceProperty { get; set; }

        /// <summary>
        /// Proprietà di destinazione per il binding.
        /// </summary>
        public string TargetProperty { get; set; }

        /// <summary>
        /// Oggetto sorgente del binding (ViewModel).
        /// </summary>
        public object Source
        {
            get => _source;
            set
            {
                _source = value;
                SetupBinding();
            }
        }

        /// <summary>
        /// Oggetto target del binding (UI Component).
        /// </summary>
        public object Target
        {
            get => _target;
            set
            {
                _target = value;
                SetupBinding();
            }
        }

        protected override void OnAttached()
        {
            SetupBinding();
        }

        private void SetupBinding()
        {
            if (Source == null || Target == null || string.IsNullOrEmpty(SourceProperty) || string.IsNullOrEmpty(TargetProperty))
                return;

            _sourceProperty = Source.GetType().GetProperty(SourceProperty);
            _targetProperty = Target.GetType().GetProperty(TargetProperty);

            if (_sourceProperty == null || _targetProperty == null)
                return;

            if (Mode == BindingMode.OneWay || Mode == BindingMode.TwoWay)
            {
                UpdateTarget();
                if (Source is INotifyPropertyChanged sourceNotify)
                {
                    sourceNotify.PropertyChanged += OnSourcePropertyChanged;
                }
            }

            if (Mode == BindingMode.TwoWay)
            {
                if (Target is INotifyPropertyChanged targetNotify)
                {
                    targetNotify.PropertyChanged += OnTargetPropertyChanged;
                }
            }
        }

        private void OnSourcePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == SourceProperty)
            {
                UpdateTarget();
            }
        }

        private void OnTargetPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == TargetProperty && Mode == BindingMode.TwoWay)
            {
                UpdateSource();
            }
        }

        private void UpdateTarget()
        {
            if (_sourceProperty != null && _targetProperty != null)
            {
                var value = _sourceProperty.GetValue(Source);
                _targetProperty.SetValue(Target, value);
            }
        }

        private void UpdateSource()
        {
            if (_sourceProperty != null && _targetProperty != null)
            {
                var value = _targetProperty.GetValue(Target);
                _sourceProperty.SetValue(Source, value);
            }
        }

        protected override void OnDetaching()
        {
            if (Source is INotifyPropertyChanged sourceNotify)
            {
                sourceNotify.PropertyChanged -= OnSourcePropertyChanged;
            }

            if (Target is INotifyPropertyChanged targetNotify)
            {
                targetNotify.PropertyChanged -= OnTargetPropertyChanged;
            }
        }
    }
}
