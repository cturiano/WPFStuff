using System;
using System.Globalization;
using Chat.Controls;
using Chat.Core.ViewModels;

namespace Chat.Converters
{
    internal class PopupContentConverter : BaseValueConverter<PopupContentConverter>
    {
        #region Public Methods

        /// <inheritdoc />
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            if (value is ChatAttachmentPopupMenuViewModel popup)
            {
                return new VerticalMenu {DataContext = popup.Content};
            }

            return null;
        }

        /// <inheritdoc />
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        #endregion
    }
}