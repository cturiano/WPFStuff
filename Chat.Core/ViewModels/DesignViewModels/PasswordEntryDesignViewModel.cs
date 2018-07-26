namespace Chat.Core.ViewModels.DesignViewModels
{
    public class PasswordEntryDesignViewModel : PasswordEntryViewModel
    {
        #region Static Fields and Constants

        public static PasswordEntryDesignViewModel Instance = new PasswordEntryDesignViewModel();

        #endregion

        #region Constructors

        private PasswordEntryDesignViewModel()
        {
            Label = "Design";
        }

        #endregion
    }
}