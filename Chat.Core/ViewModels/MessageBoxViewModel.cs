namespace Chat.Core.ViewModels
{
    public class MessageBoxViewModel : BaseDialogViewModel
    {
        #region Properties

        public string Message { get; set; }

        public string OkText { get; set; } = "OK";

        #endregion
    }
}