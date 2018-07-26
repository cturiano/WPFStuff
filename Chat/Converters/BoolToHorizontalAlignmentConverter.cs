using System;
using System.Globalization;
using System.Windows;

namespace Chat.Converters
{
    internal class BoolToHorizontalAlignmentConverter : BaseValueConverter<BoolToHorizontalAlignmentConverter>
    {
        #region Public Methods

        /// <inheritdoc />
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                return value != null && (bool)value ? HorizontalAlignment.Left : HorizontalAlignment.Right;
            }

            return value != null && (bool)value ? HorizontalAlignment.Right : HorizontalAlignment.Left;
        }

        /// <inheritdoc />
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        #endregion
    }
}