using System;
using System.Diagnostics;
using System.Globalization;
using Chat.Core.ViewModels;

namespace Chat.Converters
{
    internal class IoCConverter : BaseValueConverter<IoCConverter>
    {
        #region Public Methods

        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            switch ((string)parameter)
            {
                case nameof(ApplicationViewModel):
                    return Core.IOC.IoC.Get<ApplicationViewModel>();
                case nameof(LoginViewModel):
                    return Core.IOC.IoC.Get<LoginViewModel>();
                case nameof(RegisterViewModel):
                    return Core.IOC.IoC.Get<RegisterViewModel>();
                case nameof(ChatListViewModel):
                    return Core.IOC.IoC.Get<ChatListViewModel>();
                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        #endregion
    }
}