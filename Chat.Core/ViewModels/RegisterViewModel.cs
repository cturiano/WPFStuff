using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using Chat.Core.Extensions;
using Chat.Core.Infrastructure;
using Chat.Core.Interfaces;
using Chat.Core.IOC;
using Chat.Core.Models;

namespace Chat.Core.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Properties

        public string Email { get; set; }

        public ICommand LoginCommand => new RelayCommand(Login);

        public SecureString Password { get; set; }

        public ICommand RegisterCommand => new ParameterizedRelayCommand(async parameter => await RegisterAsync(parameter));

        public bool RegisterRunning { get; set; }

        #endregion

        #region Private Methods

        private static void Login()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login, new LoginViewModel());
        }

        private async Task RegisterAsync(object parameter)
        {
            try
            {
                await RunCommand(() => RegisterRunning,
                                 async () =>
                                 {
                                     if (parameter is IHavePassword hasPassword)
                                     {
                                         await Task.Delay(500);      
                                         IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Chat, new ChatMessageListViewModel());

                                         //var pwd = hasPassword.Password.Decrypt();
                                     }
                                     else
                                     {
                                         throw new ArgumentException("parameter does not cast to IHavePassword.", nameof(parameter));
                                     }
                                 });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion
    }
}