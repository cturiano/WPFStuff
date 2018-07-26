using System.Threading.Tasks;

namespace Chat.Core.ViewModels
{
    public class ChatMessageListItemImageAttachmentViewModel : ChatMessageListItemBaseViewModel
    {
        #region Fields

        private string _thumbnailUrl;

        #endregion

        #region Properties

        public byte[] File { get; set; }

        public string FileName { get; set; }

        public long FileSize { get; set; }

        public string LocalFilePath { get; set; } = string.Empty;

        public string ThumbnailUrl
        {
            get => _thumbnailUrl;
            set
            {
                if (_thumbnailUrl != value)
                {
                    _thumbnailUrl = value;
                    Task.Delay(15000).ContinueWith(t=>LocalFilePath = "C:\\Users\\cturian\\Desktop\\other\\WpfTutorial\\Chat\\Images\\Samples\\rusty.jpg");
                }
            }
        }

        public string Title { get; set; }

        #endregion
    }
}