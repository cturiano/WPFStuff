using System;
using System.Globalization;
using System.Windows;

namespace Chat.Converters
{
    internal class HasPropertyToVisibilityConverter : BaseValueConverter<HasPropertyToVisibilityConverter>
    {
        #region Public Methods

        /// <summary>
        ///     Convert from type to <see cref="Visibility" />.
        /// </summary>
        /// <param name="value">Reference value.</param>
        /// <param name="targetType">Not used.</param>
        /// <param name="parameter">Name of the type to check for.</param>
        /// <param name="culture">Not used.</param>
        /// <returns>Visibility.Visible if the value is of the type represented in the parameter, otherwise Visibility.Hidden.</returns>
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            // Declare variables
            var result = Visibility.Collapsed;

            // Validate input
            if (parameter is string s && !string.IsNullOrEmpty(s) && value != null && value.GetType().GetProperty(s) != null)
            {
                result = Visibility.Visible;
            }

            return result;
        }

        /// <summary>
        ///     Not supported.
        /// </summary>
        /// <param name="value">Not used.</param>
        /// <param name="targetType">Not used.</param>
        /// <param name="parameter">Not used.</param>
        /// <param name="culture">Not used.</param>
        /// <returns>Not supported.</returns>
        [Obsolete("Not supported", true)]
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        #endregion
    }
}