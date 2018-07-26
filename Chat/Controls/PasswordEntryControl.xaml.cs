using System.Windows;
using Chat.Core.ViewModels;

namespace Chat.Controls
{
    /// <inheritdoc cref="TextEntryControl" />
    /// <summary>
    ///     Interaction logic for PasswordEntryControl.xaml
    /// </summary>
    public partial class PasswordEntryControl
    {
        #region Constructors

        public PasswordEntryControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        private void ConfirmPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel vm)
            {
                vm.ConfirmPassword = ConfirmPassword.SecurePassword;
            }
        }

        private void NewPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel vm)
            {
                vm.NewPassword = NewPassword.SecurePassword;
            }
        }

        private void OriginalPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel vm)
            {
                vm.CurrentPassword = CurrentPassword.SecurePassword;
            }
        }

        #endregion
    }
}