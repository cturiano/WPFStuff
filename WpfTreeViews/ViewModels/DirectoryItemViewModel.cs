using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using WpfTreeViews.Models;

namespace WpfTreeViews.ViewModels
{
    internal class DirectoryItemViewModel : BaseViewModel
    {
        #region Constructors

        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            FullPath = fullPath;
            Type = type;
            ExpandCommand = new RelayCommand(Expand);
            ClearChildren();
        }

        #endregion

        #region Properties

        public bool CanExpand => Type != DirectoryItemType.File;

        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        public ICommand ExpandCommand { get; set; }

        public string FullPath { get; set; }

        public bool IsExpanded
        {
            get
            {
                return Children.Any(f => f != null);
            }
            set
            {
                if (value)
                {
                    Expand();
                }
                else
                {
                    ClearChildren();
                }
            }
        }

        public string Name => Type == DirectoryItemType.Drive ? FullPath : Path.GetFileName(FullPath);

        public DirectoryItemType Type { get; set; }

        #endregion

        #region Private Methods

        private void ClearChildren()
        {
            Children = new ObservableCollection<DirectoryItemViewModel>();
            if (CanExpand)
            {
                Children?.Add(null);
            }
        }

        private void Expand()
        {
            if (Type != DirectoryItemType.File)
            {
                Children = new ObservableCollection<DirectoryItemViewModel>(DirectoryStructure.GetDirectoryContents(FullPath).Select(c => new DirectoryItemViewModel(c.FullPath, c.Type)));DirectoryStructure.GetDirectoryContents(FullPath).Select(c => new DirectoryItemViewModel(c.FullPath, c.Type));
            }   
        }

        #endregion
    }
}