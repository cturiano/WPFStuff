using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Chat.AttachedProperties
{
    internal class NoFrameHistoryProperty : BaseAttachedProperty<NoFrameHistoryProperty, bool>
    {
        #region Public Methods

        /// <inheritdoc />
        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Frame frame)
            {
                frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
                frame.Navigated += (s, args) => ((Frame)s).NavigationService.RemoveBackEntry();
            }
        }

        #endregion
    }
}