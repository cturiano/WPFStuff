using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using Chat.Core.Infrastructure;
using Chat.Core.Interfaces;
using Chat.Core.IOC;
using Chat.Core.Models;

namespace Chat.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Properties

        public string Email { get; set; }

        public ICommand LoginCommand => new ParameterizedRelayCommand(async parameter => await LoginAsync(parameter));

        public bool LoginRunning { get; set; }

        public SecureString Password { get; set; }

        public ICommand RegisterCommand => new RelayCommand(Register);

        #endregion

        #region Private Methods

        private async Task LoginAsync(object parameter)
        {
            try
            {
                await RunCommand(() => LoginRunning,
                                 async () =>
                                 {
                                     if (parameter is IHavePassword hasPassword)
                                     {
                                         await Task.Delay(500);

                                         IoC.SettingsViewModel.EmailViewModel = new TextEntryViewModel {Label = "Email", OriginalText = "bob@dobbs.com"};
                                         IoC.SettingsViewModel.NameViewModel = new TextEntryViewModel {Label = "Name", OriginalText = "Bob Dobbs"};
                                         IoC.SettingsViewModel.PasswordViewModel = new PasswordEntryViewModel {Label = "Password"};
                                         IoC.SettingsViewModel.UserNameViewModel = new TextEntryViewModel {Label = "Username", OriginalText = "Bob"};
                                         IoC.SettingsViewModel.LogoutButtonText = "Logout";

                                         IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Chat, new ChatMessageListViewModel());
                                     }
                                     else
                                     {
                                         throw new ArgumentException("parameter does not cast to IHavePassword.", nameof(hasPassword));
                                     }
                                 });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static void Register()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Register, new RegisterViewModel());
        }

        #endregion
    }
}