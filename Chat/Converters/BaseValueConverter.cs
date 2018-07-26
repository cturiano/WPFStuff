using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Chat.Converters
{
    internal abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter where T : class, new()
    {
        #region Static Fields and Constants

        private static T _converter;

        #endregion

        #region Public Methods

        public abstract object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        public override object ProvideValue(IServiceProvider serviceProvider) => _converter ?? (_converter = new T());

        #endregion
    }
}