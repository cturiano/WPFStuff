using System.Windows;
using System.Windows.Controls;

namespace Chat.ViewModels
{
    public class DialogViewModel : WindowViewModel
    {
        #region Constructors

        public DialogViewModel(Window window) : base(window)
        {
            WindowMinimumHeight = 100;
            WindowMinimumWidth = 250;
            TitleHeight = 30;
        }

        #endregion

        #region Properties

        public Control Content { get; set; }

        public string Title { get; set; }

        #endregion
    }
}