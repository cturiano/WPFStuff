using System.IO;

namespace WpfTreeViews.Models
{
    internal class DirectoryItem
    {
        #region Constructors

        public DirectoryItem(string path, DirectoryItemType type)
        {
            FullPath = path;
            Type = type;
        }

        #endregion

        #region Properties

        public string FullPath { get; }
        public string Name => Path.GetFileName(FullPath);

        public DirectoryItemType Type { get; }

        #endregion
    }
}