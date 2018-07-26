using System;
using System.Globalization;
using System.Windows;

namespace Chat.Converters
{
    internal class InverseBoolToCollapsedVisibilityConverter : BaseValueConverter<InverseBoolToCollapsedVisibilityConverter>
    {
        #region Public Methods

        /// <inheritdoc />
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                return value != null && (bool)value ? Visibility.Visible : Visibility.Collapsed;
            }

            return value != null && (bool)value ? Visibility.Collapsed : Visibility.Visible;
        }

        /// <inheritdoc />
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        #endregion
    }
}