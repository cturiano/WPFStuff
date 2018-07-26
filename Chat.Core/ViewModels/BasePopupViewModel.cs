using Chat.Core.Models;

namespace Chat.Core.ViewModels
{
    public class BasePopupViewModel : BaseViewModel
    {
        #region Constructors

        public BasePopupViewModel()
        {
            ArrowAlignment = ElementHorizontalAlignment.Left;
            BubbleBackground = "ff0000";
        }

        #endregion

        #region Properties

        public ElementHorizontalAlignment ArrowAlignment { get; set; }

        public string BubbleBackground { get; set; }

        public BaseViewModel Content { get; set; }

        #endregion
    }
}