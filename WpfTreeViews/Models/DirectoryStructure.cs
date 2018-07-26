using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WpfTreeViews.Models
{
    internal static class DirectoryStructure
    {
        #region Public Methods

        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            var contents = new List<DirectoryItem>();

            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    contents.AddRange(dirs.Select(d => new DirectoryItem(d, DirectoryItemType.Folder)));
                }
            }
            catch
            {
            }

            try
            {
                var files = Directory.GetFiles(fullPath);
                if (files.Length > 0)
                {
                    contents.AddRange(files.Select(f => new DirectoryItem(f, DirectoryItemType.File)));
                }
            }
            catch
            {
            }

            return contents;
        }

        public static List<DirectoryItem> GetLogicalDrives()
        {
            return Directory.GetLogicalDrives().Select(d => new DirectoryItem(d, DirectoryItemType.Drive)).ToList();
        }

        #endregion
    }
}