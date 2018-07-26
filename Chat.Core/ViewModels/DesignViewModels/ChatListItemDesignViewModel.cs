namespace Chat.Core.ViewModels.DesignViewModels
{
    public class ChatListItemDesignViewModel : ChatListItemViewModel
    {
        #region Static Fields and Constants

        private static ChatListItemDesignViewModel _instance;
        private static readonly object Lock = new object();

        #endregion

        #region Constructors

        private ChatListItemDesignViewModel()
        {
            Name = "Bob Dobbs";
            Initials = "BD";
            Message = "A very very very very very very long message.";
            ProfilePictureRGB = "3099c5";
            NewContentAvailable = false;
            IsSelected = false;
        }

        #endregion

        #region Properties

        public static ChatListItemDesignViewModel Instance
        {
            get
            {
                lock (Lock)
                {
                    return _instance ?? (_instance = new ChatListItemDesignViewModel());
                }
            }
        }

        #endregion
    }
}