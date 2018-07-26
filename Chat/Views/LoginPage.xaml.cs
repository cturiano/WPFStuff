using System.Security;
using Chat.Core.Interfaces;
using Chat.Core.Models;
using Chat.Core.ViewModels;

namespace Chat.Views
{
    /// <inheritdoc cref="BasePage{TViewModel}" />
    /// <summary>
    ///     Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : IHavePassword
    {
        #region Constructors

        public LoginPage(LoginViewModel viewModel) : base(viewModel)
        {          
            Init();
        }

        public LoginPage()
        {
            Init();
        }

        #endregion

        #region Properties

        /// <inheritdoc />
        public SecureString Password => PasswordText.SecurePassword;

        #endregion

        #region Private Methods

        private void Init()
        {
            InitializeComponent();
            PageType = ApplicationPage.Login;
        }

        #endregion
    }
}