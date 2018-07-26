using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Chat.Core.Infrastructure;

namespace Chat.Core.ViewModels
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region Constructors

        public ChatMessageListViewModel() => Items = new ObservableCollection<ChatMessageListItemBaseViewModel>();

        #endregion

        #region Properties

        public bool AnyPopupVisible => AttachmentMenuVisible || EmojiMenuVisible;

        public ICommand AttachCommand => new RelayCommand(ShowAttachMenu);

        public bool AttachmentMenuVisible { get; set; }

        public BasePopupViewModel AttachmentViewModel { get; set; } = new ChatAttachmentPopupMenuViewModel();

        public bool EmojiMenuVisible { get; set; }

        public BasePopupViewModel EmojiViewModel { get; set; } = new ChatEmojiPopupMenuViewModel();

        public ObservableCollection<ChatMessageListItemBaseViewModel> Items { get; set; }

        public string PendingMessageText { get; set; }

        public ICommand PopupHideCommand => new RelayCommand(PopupHide);

        public ICommand SendCommand => new RelayCommand(async () => await SendAsync());

        public ICommand ShowEmojiCommand => new RelayCommand(ShowEmoji);

        #endregion

        #region Private Methods

        private void PopupHide()
        {
            AttachmentMenuVisible = false;
            EmojiMenuVisible = false;
        }

        private async Task SendAsync()
        {
            if (!string.IsNullOrEmpty(PendingMessageText))
            {
                //Items.Add(new ChatMessageListItemBaseViewModel()
                //          {
                //              IsSelected = false,
                //              Message = PendingMessageText,
                //              MessageSentTime = DateTimeOffset.Now,
                //              SenderName = "Bob Dobbs",
                //              SentByCurrentUser = true,
                //              IsNewItem = true
                //          });

                Items.Add(new ChatMessageListItemImageAttachmentViewModel()
                          {
                              IsSelected = false,  
                              Message = "Check out this picture!",
                              MessageSentTime = DateTimeOffset.Now,
                              SenderName = "Bob Dobbs",
                              SentByCurrentUser = true,
                              IsNewItem = true,
                              ThumbnailUrl = "doood"
                          });

                PendingMessageText = string.Empty;
            }
        }

        private void ShowAttachMenu()
        {
            AttachmentMenuVisible ^= true;
            EmojiMenuVisible = false;
        }

        private void ShowEmoji()
        {
            EmojiMenuVisible ^= true;
            AttachmentMenuVisible = false;
        }

        #endregion
    }
}