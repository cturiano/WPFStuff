using System.Security;
using Chat.Core.Extensions;
using Chat.Core.IOC;

namespace Chat.Core.ViewModels
{
    public class PasswordEntryViewModel : BaseEntryViewModel
    {
        #region Constructors

        public PasswordEntryViewModel()
        {
            ConfirmPasswordHintText = "Confirm Password";
            NewPasswordHintText = "New Password";
            CurrentPasswordHintText = "Original Password";
        }

        #endregion

        #region Properties

        public SecureString ConfirmPassword { get; set; }

        public string ConfirmPasswordHintText { get; set; }

        public SecureString CurrentPassword { get; set; }

        public string CurrentPasswordHintText { get; set; }

        public string FakePassword => "********";

        public SecureString NewPassword { get; set; }

        public string NewPasswordHintText { get; set; }

        #endregion

        #region Protected Methods

        protected override void Edit()
        {
            NewPassword = new SecureString();
            ConfirmPassword = new SecureString();

            base.Edit();
        }

        protected override void Save()
        {
            var storedPassword = "password".ToSecureString();

            if (!storedPassword.IsEqualTo(CurrentPassword))
            {
                IoC.UIManager.ShowMessageBox(new MessageBoxViewModel {Message = "The passwords don't match", Title = "Password Mismatch"});
                return;
            }

            if (!NewPassword.IsEqualTo(ConfirmPassword))
            {
                IoC.UIManager.ShowMessageBox(new MessageBoxViewModel {Message = "The passwords don't match", Title = "Password Mismatch"});
                return;
            }

            CurrentPassword = NewPassword.Copy();
            Cancel();
        }

        #endregion
    }
}