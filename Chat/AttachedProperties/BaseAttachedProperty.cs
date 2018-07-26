using System;
using System.Windows;

namespace Chat.AttachedProperties
{
    internal abstract class BaseAttachedProperty<TParent, TProperty> where TParent : new()
    {
        #region Static Fields and Constants

        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(TProperty), typeof(BaseAttachedProperty<TParent, TProperty>), new UIPropertyMetadata(default(TProperty), OnValuePropertyChanged, OnValuePropertyUpdated));

        #endregion

        #region Events and Delegates

        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, args) => { };

        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };

        #endregion

        #region Properties

        public static TParent Parent { get; } = new TParent();

        #endregion

        #region Public Methods

        public static TProperty GetValue(DependencyObject element) => (TProperty)element.GetValue(ValueProperty);

        public virtual void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        public virtual void OnValueUpdated(DependencyObject d, object value)
        {
        }

        public static void SetValue(DependencyObject element, TProperty value) => element.SetValue(ValueProperty, value);

        #endregion

        #region Private Methods

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (Parent is BaseAttachedProperty<TParent, TProperty>)
            {
                (Parent as BaseAttachedProperty<TParent, TProperty>).ValueChanged(d, e);
                (Parent as BaseAttachedProperty<TParent, TProperty>).OnValueChanged(d, e);
            }
        }

        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            if (Parent is BaseAttachedProperty<TParent, TProperty>)
            {
                (Parent as BaseAttachedProperty<TParent, TProperty>).OnValueUpdated(d, value);
                (Parent as BaseAttachedProperty<TParent, TProperty>).ValueUpdated(d, value);
            }

            return value;
        }

        #endregion
    }
}