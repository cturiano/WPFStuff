using System.Collections.Generic;

namespace Chat.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        #region Constructors

        public MenuViewModel() => MenuItems = new List<MenuItemViewModel>(10);

        #endregion

        #region Properties
              
        public List<MenuItemViewModel> MenuItems { get; set; }

        #endregion
    }
}