using System.Windows;
using Chat.Core.Interfaces;
using Chat.Core.Models;
using Chat.Core.ViewModels;
using Chat.IoC;
using Chat.Views;

namespace Chat
{
    /// <inheritdoc />
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        #region Protected Methods

        /// <inheritdoc />
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ApplicationSetup();
            Current.MainWindow = new MainWindow(); 
            Core.IOC.IoC.ApplicationViewModel.GoToPage(ApplicationPage.Login, new LoginViewModel());
            Current.MainWindow.Show();
        }

        #endregion

        #region Private Methods

        private void ApplicationSetup()
        {
            Core.IOC.IoC.Setup();
            Core.IOC.IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());
        }

        #endregion
    }
}