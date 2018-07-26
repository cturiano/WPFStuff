using Chat.Core.Models;

namespace Chat.Core.ViewModels.DesignViewModels
{
    public class MenuItemDesignViewModel : MenuItemViewModel
    {
        #region Static Fields and Constants

        public static MenuItemDesignViewModel Instance = new MenuItemDesignViewModel();

        #endregion

        #region Constructors

        public MenuItemDesignViewModel()
        {
            Icon = IconType.File;
            Text = "this is some text";
            Type = MenuItemType.TextAndIcon;
        }

        #endregion
    }
}