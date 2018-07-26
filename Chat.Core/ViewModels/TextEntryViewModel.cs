namespace Chat.Core.ViewModels
{
    public class TextEntryViewModel : BaseEntryViewModel
    {
        #region Properties

        public string EditedText { get; set; }

        public string OriginalText { get; set; }

        #endregion

        #region Protected Methods

        protected override void Edit()
        {
            EditedText = OriginalText;
            base.Edit();
        }

        protected override void Save()
        {
            OriginalText = EditedText;
            base.Save();
        }

        #endregion
    }
}