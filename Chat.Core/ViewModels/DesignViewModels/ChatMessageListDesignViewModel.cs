using System;
using System.Linq;

namespace Chat.Core.ViewModels.DesignViewModels
{
    public class ChatMessageListDesignViewModel : ChatMessageListViewModel
    {
        #region Static Fields and Constants

        private static ChatMessageListDesignViewModel _instance;
        private static DateTimeOffset _start = new DateTimeOffset(1970, 1, 1, 1, 1, 1, 1, new TimeSpan(0));
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly object Lock = new object();
        private static readonly Random Random = new Random();
        private const string RGBChars = "ABCDE0123456789";

        #endregion

        #region Constructors

        private ChatMessageListDesignViewModel()
        {
            Items.Add(ChatMessageListItemDesignViewModel.Instance);
            GenerateItems();
        }

        #endregion

        #region Properties

        public static ChatMessageListDesignViewModel Instance
        {
            get
            {
                lock (Lock)
                {
                    return _instance ?? (_instance = new ChatMessageListDesignViewModel());
                }
            }
        }

        #endregion

        #region Private Methods

        private void GenerateItems()
        {
            for (var i = 0; i < Random.Next(1, 100); i++)
            {
                var item = new ChatMessageListItemBaseViewModel()
                           {
                               Initials = GenerateRandomString(2, Chars),
                               IsSelected = Random.Next(1, 15) % 2 > 0,
                               Message = GenerateRandomString(Random.Next(1 ,300), Chars),
                               ProfilePictureRGB = GenerateRandomString(6, RGBChars),
                               SenderName = GenerateRandomString(Random.Next(1, 10), Chars),
                               SentByCurrentUser = Random.Next(1, 15) % 2 > 0,
                               MessageReadTime = GenerateRandomDay(),
                               MessageSentTime = GenerateRandomDay()
                           };

                Items.Add(item);
            }
        }

        private static DateTimeOffset GenerateRandomDay()
        {
            return _start.AddTicks(Random.Next(1, (int)(DateTime.Today - _start).Ticks));
        }

        private static string GenerateRandomString(int length, string chars)
        {
            return new string(Enumerable.Repeat(chars, length).Select(s => s[Random.Next(1, Math.Max(s.Length, 5))]).ToArray());
        }

        #endregion
    }
}