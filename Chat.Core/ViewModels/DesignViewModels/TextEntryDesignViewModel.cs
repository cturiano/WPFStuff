namespace Chat.Core.ViewModels.DesignViewModels
{
    public class TextEntryDesignViewModel : TextEntryViewModel
    {
        #region Static Fields and Constants

        public static TextEntryDesignViewModel Instance = new TextEntryDesignViewModel();

        #endregion

        #region Constructors

        private TextEntryDesignViewModel()
        {
            Label = "Design";
            OriginalText = "**********";
            EditedText = "5555555555";
        }

        #endregion
    }
}