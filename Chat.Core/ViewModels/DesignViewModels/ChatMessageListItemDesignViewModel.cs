using System;

namespace Chat.Core.ViewModels.DesignViewModels
{
    public class ChatMessageListItemDesignViewModel : ChatMessageListItemBaseViewModel
    {
        #region Static Fields and Constants

        private static ChatMessageListItemDesignViewModel _instance;
        private static readonly object Lock = new object();

        #endregion

        #region Constructors

        private ChatMessageListItemDesignViewModel()
        {
            Initials = "BD";
            IsSelected = true;
            Message = "A very very very very very very long message.";
            ProfilePictureRGB = "3099c5";
            SenderName = "Bob";
            SentByCurrentUser = false;
            MessageReadTime = DateTimeOffset.Now;
            MessageSentTime = DateTimeOffset.Now - new TimeSpan(1, 1, 1, 1);
        }

        #endregion

        #region Properties

        public static ChatMessageListItemDesignViewModel Instance
        {
            get
            {
                lock (Lock)
                {
                    return _instance ?? (_instance = new ChatMessageListItemDesignViewModel());
                }
            }
        }

        #endregion
    }
}