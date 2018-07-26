using System;
using System.Linq;
using Chat.Core.Models;

namespace Chat.Core.ViewModels.DesignViewModels
{
    public class MenuDesignViewModel : MenuViewModel
    {
        #region Static Fields and Constants

        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly Random Random = new Random();

        #endregion

        #region Constructors

        private MenuDesignViewModel()
        {
            var item = new MenuItemViewModel
                                 {
                                     Type = MenuItemType.Header,
                                     Icon = IconType.None,
                                     Text = "Design Time Header..."
                                 };

            MenuItems.Add(item);
            GenerateItems();
        }

        #endregion

        #region Properties

        public static MenuDesignViewModel Instance { get; } = new MenuDesignViewModel();

        #endregion

        #region Private Methods

        private void GenerateItems()
        {
            for (var i = 0; i < Random.Next(1, 10); i++)
            {
                var item = new MenuItemViewModel
                           {
                               Type = (MenuItemType)Random.Next(2, Enum.GetNames(typeof(MenuItemType)).Length),
                               Icon = (IconType)Random.Next(1, Enum.GetNames(typeof(IconType)).Length),
                               Text = GenerateRandomString(15, Chars)
                           };

                MenuItems.Add(item);
            }
        }

        private static string GenerateRandomString(int length, string chars)
        {
            return new string(Enumerable.Repeat(chars, length).Select(s => s[Random.Next(1, s.Length)]).ToArray());
        }

        #endregion
    }
}