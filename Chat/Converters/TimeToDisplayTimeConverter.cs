using System;
using System.Globalization;

namespace Chat.Converters
{
    internal class TimeToDisplayTimeConverter : BaseValueConverter<TimeToDisplayTimeConverter>
    {
        #region Public Methods

        /// <inheritdoc />
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var time = (DateTimeOffset)value;
                return time.ToLocalTime().ToString(time.Date == DateTimeOffset.UtcNow.Date ? "HH:mm" : "HH:mm, dd MMM yyyy");
            }

            return string.Empty;
        }

        /// <inheritdoc />
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        #endregion
    }
}