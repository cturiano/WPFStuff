using System;
using System.Globalization;
using System.Windows;

namespace Chat.Converters
{
    internal class HorizontalAlignmentConverter : BaseValueConverter<HorizontalAlignmentConverter>
    {
        #region Public Methods

        /// <inheritdoc />
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {        
            if (value == null)
            {                           
                return HorizontalAlignment.Left;
            }

            return (HorizontalAlignment)value;
        }

        /// <inheritdoc />
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        #endregion
    }
}