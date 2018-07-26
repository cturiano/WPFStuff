using Chat.Core.Models;

namespace Chat.Core.ViewModels
{
    public class ApplicationViewModel : BaseViewModel
    {
        #region Properties

        public ApplicationPage CurrentPage { get; private set; }

        public BaseViewModel CurrentViewModel { get; private set; }

        public bool SettingsVisible { get; set; }

        public bool SideMenuVisible { get; set; }

        #endregion

        #region Public Methods

        public void GoToPage(ApplicationPage page, BaseViewModel viewModel =  null)
        {                             
            SettingsVisible = false;   
            CurrentViewModel = viewModel;

            CurrentPage = page;
            OnPropertyChanged(nameof(CurrentPage));
            SideMenuVisible = page == ApplicationPage.Chat;
        }

        #endregion
    }
}