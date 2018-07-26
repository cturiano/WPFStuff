using System;
using System.Globalization;
using System.Windows;
using Chat.Core.Models;

namespace Chat.Converters
{
    internal class IconTypeToStringConverter : BaseValueConverter<IconTypeToStringConverter>
    {
        #region Public Methods

        /// <inheritdoc />
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            var retVal = string.Empty;
            var type = value is IconType iconType ? iconType : IconType.None;
            switch (type)
            {
                case IconType.Picture:
                    retVal = Application.Current.FindResource("FontAwesomePictureIcon").ToString();
                    break;
                case IconType.File:
                    retVal = Application.Current.FindResource("FontAwesomeFileIcon").ToString();
                    break;
                case IconType.Folder:
                    retVal = Application.Current.FindResource("FontAwesomeFolderIcon").ToString();
                    break;
                case IconType.Audio:
                    retVal = Application.Current.FindResource("FontAwesomeAudioIcon").ToString();
                    break;
                case IconType.Video:
                    retVal = Application.Current.FindResource("FontAwesomeVideoIcon").ToString();
                    break;
                case IconType.None:
                default:
                    break;
            }

            return retVal;
        }

        /// <inheritdoc />
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        #endregion
    }
}