using System;
using System.Globalization;

namespace Chat.Converters
{
    internal class BoolToColumnConverter : BaseValueConverter<BoolToColumnConverter>
    {
        #region Public Methods

        /// <inheritdoc />
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                return value != null && (bool)value ? 0 : 2;
            }

            return value != null && (bool)value ? 2 : 0;
        }

        /// <inheritdoc />
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        #endregion
    }
}