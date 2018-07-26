using Chat.Core.Interfaces;
using Chat.Core.ViewModels;
using Ninject;

namespace Chat.Core.IOC
{
    public static class IoC
    {
        #region Properties

        public static ApplicationViewModel ApplicationViewModel => Get<ApplicationViewModel>();

        public static IKernel Kernel { get; } = new StandardKernel();

        public static SettingsViewModel SettingsViewModel => Get<SettingsViewModel>();

        public static IUIManager UIManager => Get<IUIManager>();

        #endregion

        #region Public Methods

        public static T Get<T>() => Kernel.Get<T>();

        public static void Setup()
        {
            BindViewModels();
        }

        #endregion

        #region Private Methods

        private static void BindViewModels()
        {
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
            Kernel.Bind<LoginViewModel>().ToConstant(new LoginViewModel());
            Kernel.Bind<RegisterViewModel>().ToConstant(new RegisterViewModel());
            Kernel.Bind<ChatListViewModel>().ToConstant(new ChatListViewModel());
            Kernel.Bind<SettingsViewModel>().ToConstant(new SettingsViewModel());
        }

        #endregion
    }
}