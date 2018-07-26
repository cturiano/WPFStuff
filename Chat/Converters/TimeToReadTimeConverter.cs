using System;
using System.Globalization;

namespace Chat.Converters
{
    internal class TimeToReadTimeConverter : BaseValueConverter<TimeToReadTimeConverter>
    {
        #region Public Methods

        /// <inheritdoc />
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var time = (DateTimeOffset)value;

                if (time == DateTimeOffset.MinValue)
                {
                    return string.Empty;
                }    

                return time.Date == DateTimeOffset.UtcNow.Date ? $"Read {time.ToLocalTime():HH:mm}" : $"Read {time.ToLocalTime():HH:mm, dd MMM yyyy}";
            }

            return string.Empty;
        }

        /// <inheritdoc />
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        #endregion
    }
}