using System.Windows.Input;
using Chat.Core.Infrastructure;

namespace Chat.Core.ViewModels
{
    public class BaseEntryViewModel : BaseViewModel
    {
        #region Properties

        public ICommand CancelCommand => new RelayCommand(Cancel);

        public ICommand EditCommand => new RelayCommand(Edit);

        public bool IsEditing { get; set; }

        public string Label { get; set; }

        public ICommand SaveCommand => new RelayCommand(Save);

        #endregion

        #region Protected Methods

        protected virtual void Cancel()
        {
            IsEditing = false;
        }

        protected virtual void Edit()
        {
            IsEditing = true;
        }

        protected virtual void Save()
        {
            Cancel();
        }

        #endregion
    }
}