using System;
using System.Globalization;
using System.Windows;
using Chat.Core.Models;

namespace Chat.Converters
{
    internal class ItemTypeToVisibilityConverter : BaseValueConverter<ItemTypeToVisibilityConverter>
    {
        #region Public Methods

        /// <inheritdoc />
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            if (parameter == null || value == null || !Enum.TryParse(parameter as string, out MenuItemType type))
            {
                return Visibility.Collapsed;
            }

            return (MenuItemType)value == type ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <inheritdoc />
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        #endregion
    }
}