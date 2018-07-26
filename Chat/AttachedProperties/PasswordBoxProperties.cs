using System.Windows;
using System.Windows.Controls;

namespace Chat.AttachedProperties
{
    internal class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        #region Public Methods

        public static void SetValue(DependencyObject d)
        {
            SetValue(d, ((PasswordBox)d).SecurePassword.Length > 0);
        }

        #endregion
    }

    internal class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        #region Public Methods

        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox pb)
            {
                pb.PasswordChanged -= PasswordChanged;
                if ((bool)e.NewValue)
                {
                    HasTextProperty.SetValue(pb);
                    pb.PasswordChanged += PasswordChanged;
                }
            }
        }

        #endregion

        #region Private Methods

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValue((PasswordBox)sender);
        }

        #endregion
    }
}