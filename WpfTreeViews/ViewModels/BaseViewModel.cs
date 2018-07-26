using System.ComponentModel;
using PropertyChanged;

namespace WpfTreeViews.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    internal class BaseViewModel : INotifyPropertyChanged
    {
        #region Events and Delegates

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #endregion
    }
}