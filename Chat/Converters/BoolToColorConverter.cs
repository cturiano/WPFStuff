using System;
using System.Globalization;
using System.Windows;

namespace Chat.Converters
{
    internal class BoolToColorConverter : BaseValueConverter<BoolToColorConverter>
    {
        #region Public Methods

        /// <inheritdoc />
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                return value != null && (bool)value ? Application.Current.FindResource("ForegroundLightBrush") : Application.Current.FindResource("TitleVeryLightBlueBrush");
            }

            return value != null && (bool)value ? Application.Current.FindResource("TitleVeryLightBlueBrush") : Application.Current.FindResource("ForegroundLightBrush");
        }

        /// <inheritdoc />
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        #endregion
    }
}