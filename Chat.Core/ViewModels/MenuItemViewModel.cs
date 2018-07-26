using Chat.Core.Models;

namespace Chat.Core.ViewModels
{
    public class MenuItemViewModel : BaseViewModel
    {
        #region Properties

        public IconType Icon { get; set; } = IconType.Picture;

        public string Text { get; set; } = string.Empty;

        public MenuItemType Type { get; set; } = MenuItemType.TextAndIcon;

        #endregion
    }
}