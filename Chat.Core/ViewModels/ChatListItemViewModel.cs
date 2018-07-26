using System;
using System.Windows.Input;
using Chat.Core.Infrastructure;
using Chat.Core.IOC;
using Chat.Core.Models;

namespace Chat.Core.ViewModels
{
    public class ChatListItemViewModel : BaseViewModel
    {
        #region Properties
                                                  
        public string Initials { get; set; }

        public bool IsSelected { get; set; }

        public string Message { get; set; }

        public string Name { get; set; }

        public bool NewContentAvailable { get; set; }

        public ICommand OpenChatCommand => new RelayCommand(OpenChat);

        public string ProfilePictureRGB { get; set; }

        #endregion

        #region Private Methods

        private void OpenChat()
        {
            IsSelected = true;
            var cm = new ChatMessageListViewModel();
            
            //cm.Items.Add(new ChatMessageListItemImageAttachmentViewModel()
            //             {                    
            //                 ThumbnailUrl = "blah",
            //                 Message = "Check out this picture!",
            //                 Initials = Initials,
            //                 MessageSentTime = DateTimeOffset.Now,
            //                 ProfilePictureRGB = "ff00ff",
            //                 SenderName = Name,
            //                 SentByCurrentUser = true
            //             });

            cm.Items.Add(new ChatMessageListItemBaseViewModel
                         {
                             Message = Message,
                             Initials = Initials,
                             MessageSentTime = DateTimeOffset.Now,
                             ProfilePictureRGB = "ff00ff",
                             SenderName = Name,
                             SentByCurrentUser = true
                         });

            cm.Items.Add(new ChatMessageListItemBaseViewModel
                         {
                             Message = "hey bro!",
                             Initials = "DA",
                             MessageSentTime = DateTimeOffset.Now,
                             MessageReadTime = DateTimeOffset.Now,
                             ProfilePictureRGB = "550055",
                             SenderName = "Dave Adams",
                             SentByCurrentUser = false
                         });

            //cm.Items.Add(new ChatMessageListItemBaseViewModel
            //             {
            //                 Message = "'sup mang?",
            //                 Initials = Initials,
            //                 MessageSentTime = DateTimeOffset.Now,
            //                 MessageReadTime = DateTimeOffset.Now,
            //                 ProfilePictureRGB = "FF00FF",
            //                 SenderName = Name,
            //                 SentByCurrentUser = true
            //             });

            //cm.Items.Add(new ChatMessageListItemBaseViewModel
            //             {
            //                 Message = "Dude!",
            //                 Initials = Initials,
            //                 MessageSentTime = DateTimeOffset.Now - TimeSpan.FromDays(1),
            //                 MessageReadTime = DateTimeOffset.Now - TimeSpan.FromDays(1),
            //                 ProfilePictureRGB = "ff00ff",
            //                 SenderName = Name,
            //                 SentByCurrentUser = true
            //             });

            //cm.Items.Add(new ChatMessageListItemBaseViewModel
            //             {
            //                 Message = "Lalala",
            //                 Initials = "DA",
            //                 MessageSentTime = DateTimeOffset.Now - TimeSpan.FromDays(1),
            //                 MessageReadTime = DateTimeOffset.Now - TimeSpan.FromDays(1),
            //                 ProfilePictureRGB = "550055",
            //                 SenderName = "Dave Adams",
            //                 SentByCurrentUser = false
            //             });

            //cm.Items.Add(new ChatMessageListItemBaseViewModel
            //             {
            //                 Message = "blah blah blah",
            //                 Initials = Initials,
            //                 MessageSentTime = DateTimeOffset.Now - TimeSpan.FromDays(1),
            //                 MessageReadTime = DateTimeOffset.Now - TimeSpan.FromDays(1),
            //                 ProfilePictureRGB = "FF00FF",
            //                 SenderName = Name,
            //                 SentByCurrentUser = true
            //             });

            //cm.Items.Add(new ChatMessageListItemBaseViewModel
            //             {
            //                 Message = Message,
            //                 Initials = Initials,
            //                 MessageSentTime = DateTimeOffset.Now,
            //                 ProfilePictureRGB = "ff00ff",
            //                 SenderName = Name,
            //                 SentByCurrentUser = true
            //             });

            //cm.Items.Add(new ChatMessageListItemBaseViewModel
            //             {
            //                 Message = "hey bro!",
            //                 Initials = "DA",
            //                 MessageSentTime = DateTimeOffset.Now,
            //                 MessageReadTime = DateTimeOffset.Now,
            //                 ProfilePictureRGB = "550055",
            //                 SenderName = "Dave Adams",
            //                 SentByCurrentUser = false
            //             });

            //cm.Items.Add(new ChatMessageListItemBaseViewModel
            //             {
            //                 Message = "'sup mang?",
            //                 Initials = Initials,
            //                 MessageSentTime = DateTimeOffset.Now,
            //                 MessageReadTime = DateTimeOffset.Now,
            //                 ProfilePictureRGB = "FF00FF",
            //                 SenderName = Name,
            //                 SentByCurrentUser = true
            //             });

            //cm.Items.Add(new ChatMessageListItemBaseViewModel
            //             {
            //                 Message = "Dude!",
            //                 Initials = Initials,
            //                 MessageSentTime = DateTimeOffset.Now - TimeSpan.FromDays(1),
            //                 MessageReadTime = DateTimeOffset.Now - TimeSpan.FromDays(1),
            //                 ProfilePictureRGB = "ff00ff",
            //                 SenderName = Name,
            //                 SentByCurrentUser = true
            //             });

            //cm.Items.Add(new ChatMessageListItemBaseViewModel
            //             {
            //                 Message = "Lalala",
            //                 Initials = "DA",
            //                 MessageSentTime = DateTimeOffset.Now - TimeSpan.FromDays(1),
            //                 MessageReadTime = DateTimeOffset.Now - TimeSpan.FromDays(1),
            //                 ProfilePictureRGB = "550055",
            //                 SenderName = "Dave Adams",
            //                 SentByCurrentUser = false
            //             });

            //cm.Items.Add(new ChatMessageListItemBaseViewModel
            //             {
            //                 Message = "blah blah blah",
            //                 Initials = Initials,
            //                 MessageSentTime = DateTimeOffset.Now - TimeSpan.FromDays(1),
            //                 MessageReadTime = DateTimeOffset.Now - TimeSpan.FromDays(1),
            //                 ProfilePictureRGB = "FF00FF",
            //                 SenderName = Name,
            //                 SentByCurrentUser = true
            //             });

            IoC.ApplicationViewModel.GoToPage(ApplicationPage.Chat, cm);
        }

        #endregion 
    }
}