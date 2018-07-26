using System;
using System.Globalization;
using System.Windows;

namespace Chat.Converters
{
    internal class InverseBoolToVisibilityConverter : BaseValueConverter<InverseBoolToVisibilityConverter>
    {
        #region Public Methods

        /// <inheritdoc />
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            if (value != null)
            {
                return (bool)value ? Visibility.Collapsed : Visibility.Visible;
            }

            return Visibility.Visible;
        }

        /// <inheritdoc />
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        #endregion
    }
}