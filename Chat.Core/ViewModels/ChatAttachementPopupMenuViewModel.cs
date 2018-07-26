using System.Collections.Generic;
using Chat.Core.Models;

namespace Chat.Core.ViewModels
{
    public class ChatAttachmentPopupMenuViewModel : BasePopupViewModel
    {
        #region Constructors

        public ChatAttachmentPopupMenuViewModel()
        {
            Content = new MenuViewModel
                      {
                          MenuItems = new List<MenuItemViewModel>(new[]
                                                                  {
                                                                      new MenuItemViewModel {Text = "Attach", Type = MenuItemType.Header, Icon = IconType.None},      
                                                                      new MenuItemViewModel {Text = "Folder...", Type = MenuItemType.TextAndIcon, Icon = IconType.Folder},
                                                                      new MenuItemViewModel {Text = "File...", Type = MenuItemType.TextAndIcon, Icon = IconType.File},
                                                                      new MenuItemViewModel {Text = "Picture...", Type = MenuItemType.TextAndIcon, Icon = IconType.Picture},
                                                                      new MenuItemViewModel {Text = "Audio...", Type = MenuItemType.TextAndIcon, Icon = IconType.Audio},
                                                                      new MenuItemViewModel {Text = "Video...", Type = MenuItemType.TextAndIcon, Icon = IconType.Video}
                                                                  })
                      };

            BubbleBackground = "ffffff";
        }

        #endregion
    }
}