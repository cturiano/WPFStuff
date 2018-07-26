using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Chat.AttachedProperties
{
    internal class IsFocusedProperty : BaseAttachedProperty<IsFocusedProperty, bool>
    {
        #region Public Methods

        /// <inheritdoc />
        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Control control)
            {
                control.Loaded += (s, args) => control.Focus();
            }
        }

        #endregion
    }

    internal class FocusProperty : BaseAttachedProperty<FocusProperty, bool>
    {
        #region Public Methods

        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // If we don't have a control, return
            if (!(sender is Control control))
            {
                return;
            }

            if ((bool)e.NewValue)
                // Focus this control
            {
                control.Focus();
            }
        }

        #endregion
    }

    internal class FocusAndSelectProperty : BaseAttachedProperty<FocusAndSelectProperty, bool>
    {
        #region Public Methods

        /// <inheritdoc />
        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            switch (d)
            {
                case TextBoxBase control:
                    if ((bool)e.NewValue)
                    {
                        control.Focus();
                        control.SelectAll();
                    }

                    break;
                case PasswordBox pb:
                    if ((bool)e.NewValue)
                    {
                        pb.Focus();
                        pb.SelectAll();
                    }

                    break;
            }
        }

        #endregion
    }
}