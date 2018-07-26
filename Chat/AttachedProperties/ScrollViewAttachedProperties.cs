using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Chat.AttachedProperties
{
    internal class ScrollToBottomOnLoadProperty : BaseAttachedProperty<ScrollToBottomOnLoadProperty, bool>
    {
        #region Public Methods

        /// <inheritdoc />
        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!DesignerProperties.GetIsInDesignMode(d) && d is ScrollViewer control)
            {
                control.DataContextChanged -= OnDataContextChanged;
                control.DataContextChanged += OnDataContextChanged;
            }
        }

        #endregion

        #region Private Methods

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            (sender as ScrollViewer)?.ScrollToBottom();
        }

        #endregion
    }
    
    internal class AutoScrollToBottomProperty : BaseAttachedProperty<AutoScrollToBottomProperty, bool>
    {
        #region Public Methods

        /// <inheritdoc />
        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!DesignerProperties.GetIsInDesignMode(d) && d is ScrollViewer control)
            {
                control.ScrollChanged -= OnScrollChanged;
                control.ScrollChanged += OnScrollChanged;
            }
        }

        #endregion

        #region Private Methods

        private static void OnScrollChanged(object sender, ScrollChangedEventArgs args)
        {
            if (sender is ScrollViewer scroller && scroller.ScrollableHeight - scroller.VerticalOffset < 20)
            {
                scroller.ScrollToBottom();
            }
        }

        #endregion
    }
}