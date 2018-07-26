using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using WpfTreeViews.Models;

namespace WpfTreeViews.Converters
{
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    public class DirectoryItemToBitmapConverter : IValueConverter
    {
        #region Static Fields and Constants

        public static DirectoryItemToBitmapConverter Instance = new DirectoryItemToBitmapConverter();

        #endregion

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var image = string.Empty;
            if (value != null)
            {
                var type = (DirectoryItemType)value;
                switch (type)
                {
                    case DirectoryItemType.Drive:
                        image = "Images/Drive.png";
                        break;
                    case DirectoryItemType.File:
                        image = "Images/File.png";
                        break;
                    case DirectoryItemType.Folder:
                        image = "Images/Folder Closed.png";
                        break;
                }
            }

            return new BitmapImage(new Uri($"pack://application:,,,/WpfTreeViews;component/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(nameof(ConvertBack));
        }

        #endregion
    }
}