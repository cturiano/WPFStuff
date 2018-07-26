using System.Collections.ObjectModel;
using System.Linq;
using WpfTreeViews.Models;

namespace WpfTreeViews.ViewModels
{
    internal class DirectoryViewModel : BaseViewModel
    {
        #region Constructors

        public DirectoryViewModel()
        {
            Directories = new ObservableCollection<DirectoryItemViewModel>(DirectoryStructure.GetLogicalDrives().Select(c => new DirectoryItemViewModel(c.FullPath, DirectoryItemType.Drive)));
        }

        #endregion

        #region Properties

        public ObservableCollection<DirectoryItemViewModel> Directories { get; }

        #endregion
    }
}