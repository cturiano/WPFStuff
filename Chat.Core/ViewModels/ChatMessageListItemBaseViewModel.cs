using System;

namespace Chat.Core.ViewModels
{
    public class ChatMessageListItemBaseViewModel
    {
        #region Properties

        public string Initials { get; set; }

        public bool IsNewItem { get; set; }

        public bool IsSelected { get; set; }

        public string Message { get; set; }

        public bool MessageRead => MessageReadTime > DateTimeOffset.MinValue;

        public DateTimeOffset MessageReadTime { get; set; }

        public DateTimeOffset MessageSentTime { get; set; }

        public string ProfilePictureRGB { get; set; }

        public string SenderName { get; set; }

        public bool SentByCurrentUser { get; set; }

        #endregion
    }
}