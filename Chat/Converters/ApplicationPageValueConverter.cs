using System;
using System.Diagnostics;
using System.Globalization;
using Chat.Core.Models;
using Chat.Core.ViewModels;
using Chat.Views;

namespace Chat.Converters
{
    internal class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        #region Public Methods

        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            switch (value)
            {
                case ApplicationPage.Login:
                    return new LoginPage(parameter as LoginViewModel);
                case ApplicationPage.Chat:
                    return new ChatPage(parameter as ChatMessageListViewModel);
                case ApplicationPage.Register:
                    return new RegisterPage(parameter as RegisterViewModel);
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        #endregion
    }
}