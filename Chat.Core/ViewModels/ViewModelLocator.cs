using Chat.Core.IOC;

namespace Chat.Core.ViewModels
{
    public class ViewModelLocator
    {
        #region Properties

        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();

        public static ViewModelLocator Instance { get; } = new ViewModelLocator();

        public static SettingsViewModel SettingsViewModel => IoC.Get<SettingsViewModel>();

        #endregion
    }
}