using System;
using System.Globalization;
using System.Windows;

namespace Chat.Converters
{
    internal class InverseBoolToHorizontalAlignmentConverter : BaseValueConverter<InverseBoolToHorizontalAlignmentConverter>
    {
        #region Public Methods

        /// <inheritdoc />
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                return value != null && (bool)value ? HorizontalAlignment.Right : HorizontalAlignment.Left;
            }

            return value != null && (bool)value ? HorizontalAlignment.Left : HorizontalAlignment.Right;
        }

        /// <inheritdoc />
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        #endregion
    }
}