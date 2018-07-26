using System.Windows.Input;
using Chat.Core.Infrastructure;
using Chat.Core.IOC;
using Chat.Core.Models;

namespace Chat.Core.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Properties

        public ICommand ClearUserDataCommand => new RelayCommand(ClearUserData);

        public ICommand CloseCommand => new RelayCommand(Close);

        public TextEntryViewModel EmailViewModel { get; set; }

        public string LogoutButtonText { get; set; }

        public ICommand LogoutCommand => new RelayCommand(Logout);

        public TextEntryViewModel NameViewModel { get; set; }

        public ICommand OpenCommand => new RelayCommand(Open);

        public PasswordEntryViewModel PasswordViewModel { get; set; }

        public TextEntryViewModel UserNameViewModel { get; set; }

        #endregion

        #region Private Methods

        private void ClearUserData()
        {
            NameViewModel = null;
            EmailViewModel = null;
            PasswordViewModel = null;
            UserNameViewModel = null;
        }

        private void Close()
        {
            IoC.ApplicationViewModel.SettingsVisible = false;
        }

        private void Logout()
        {
            ClearUserData();
            Close();
            IoC.ApplicationViewModel.GoToPage(ApplicationPage.Login, new LoginViewModel());
        }

        private static void Open()
        {
            IoC.ApplicationViewModel.SettingsVisible = true;
        }

        #endregion
    }
}