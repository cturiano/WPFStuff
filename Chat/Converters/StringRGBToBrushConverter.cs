using System;
using System.Globalization;
using System.Windows.Media;

namespace Chat.Converters
{
    internal class StringRGBToBrushConverter : BaseValueConverter<StringRGBToBrushConverter>
    {
        #region Public Methods

        /// <inheritdoc />
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            if (value != null)
            {
                return (SolidColorBrush)new BrushConverter().ConvertFrom($"#{value}");
            }

            return null;
        }

        /// <inheritdoc />
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        #endregion
    }
}