using System;
using System.Globalization;
using System.Windows;

namespace Chat.Converters
{
    internal class BoolToCollapsedVisibilityConverter : BaseValueConverter<BoolToCollapsedVisibilityConverter>
    {
        #region Public Methods

        /// <inheritdoc />
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            if (parameter == null)
            {
                return value != null && (bool)value ? Visibility.Collapsed : Visibility.Visible;
            }

            return value != null && (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <inheritdoc />
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        #endregion
    }
}