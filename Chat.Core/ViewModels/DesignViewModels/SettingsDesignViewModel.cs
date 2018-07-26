namespace Chat.Core.ViewModels.DesignViewModels
{
    public class SettingsDesignViewModel : SettingsViewModel
    {
        #region Static Fields and Constants

        public static SettingsDesignViewModel Instance = new SettingsDesignViewModel();

        #endregion

        #region Constructors

        public SettingsDesignViewModel()
        {
            EmailViewModel = new TextEntryViewModel {Label = "Email", OriginalText = "bob@dobbs.com"};
            NameViewModel = new TextEntryViewModel {Label = "Name", OriginalText = "Bob Dobbs"};
            PasswordViewModel = new PasswordEntryViewModel {Label = "Password"};
            UserNameViewModel = new TextEntryViewModel {Label = "Username", OriginalText = "Bob"};
            LogoutButtonText = "Logout";
        }

        #endregion
    }
}