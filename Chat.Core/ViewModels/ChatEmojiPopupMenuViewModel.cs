using System.Collections.Generic;
using Chat.Core.Models;

namespace Chat.Core.ViewModels
{
    public class ChatEmojiPopupMenuViewModel : BasePopupViewModel
    {
        #region Constructors

        public ChatEmojiPopupMenuViewModel()
        {
            Content = new MenuViewModel
                      {
                          MenuItems = new List<MenuItemViewModel>(new[]
                                                                  {
                                                                      new MenuItemViewModel {Text = "Attach a file...", Type = MenuItemType.TextAndIcon, Icon = IconType.File},
                                                                      new MenuItemViewModel {Text = "Attach a photo...", Type = MenuItemType.TextAndIcon, Icon = IconType.Picture}
                                                                  })
                      };

            ArrowAlignment = ElementHorizontalAlignment.Left;
            BubbleBackground = "ffffff";
        }

        #endregion
    }
}