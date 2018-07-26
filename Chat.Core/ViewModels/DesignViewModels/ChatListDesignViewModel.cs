using System;
using System.Linq;

namespace Chat.Core.ViewModels.DesignViewModels
{
    public class ChatListDesignViewModel : ChatListViewModel
    {
        #region Static Fields and Constants

        private static ChatListDesignViewModel _instance;
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const string RGBChars = "ABCDE0123456789";
        private static readonly object Lock = new object();
        private static readonly Random Random = new Random();

        #endregion

        #region Constructors

        private ChatListDesignViewModel()
        {
            Items.Add(ChatListItemDesignViewModel.Instance);
            GenerateItems();
        }

        #endregion

        #region Properties

        public static ChatListDesignViewModel Instance
        {
            get
            {
                lock (Lock)
                {
                    return _instance ?? (_instance = new ChatListDesignViewModel());
                }
            }
        }

        #endregion

        #region Private Methods

        private void GenerateItems()
        {
            for (var i = 0; i < Random.Next(100); i++)
            {
                var item = new ChatListItemViewModel
                           {
                               Initials = GenerateRandomString(2, Chars),
                               Message = GenerateRandomString(100, Chars),
                               Name = GenerateRandomString(Random.Next(10), Chars),
                               ProfilePictureRGB =  GenerateRandomString(6, RGBChars),
                               NewContentAvailable = (Random.Next(15) % 2) > 0,
                               IsSelected = false
                           };

                Items.Add(item);
            }
        }

        private static string GenerateRandomString(int length, string chars)
        {
            return new string(Enumerable.Repeat(chars, length).Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        #endregion
    }
}