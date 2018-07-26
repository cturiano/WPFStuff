using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfTreeViews.Converters
{
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class StringToBitmapConverter : IValueConverter
    {
        #region Static Fields and Constants

        public static StringToBitmapConverter Instance = new StringToBitmapConverter();

        #endregion

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = (string)value;
            if (!string.IsNullOrEmpty(path))
            {
                var image = "Images/File.png";
                if (Directory.Exists(path))
                {
                    var di = new DirectoryInfo(path);
                    image = di.Parent == null ? "Images/Drive.png" : "Images/Folder Closed.png";
                }
                return new BitmapImage(new Uri($"pack://application:,,,/WpfTreeViews;component/{image}"));
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(nameof(ConvertBack));
        }

        #endregion
    }
}