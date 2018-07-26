using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chat.AttachedProperties
{
    internal class ClipFromBorderProperty : BaseAttachedProperty<ClipFromBorderProperty, bool>
    {
        #region Fields

        private RoutedEventHandler _borderLoaded;
        private SizeChangedEventHandler _sizeChangedEventHandler;

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && element.Parent is Border border)
            {
                _borderLoaded = (s1, e1) => Border_OnChange(s1, e1, element);
                _sizeChangedEventHandler = (s1, e1) => Border_OnChange(s1, e1, element);

                if ((bool)e.NewValue)
                {
                    border.Loaded += _borderLoaded;
                    border.SizeChanged += _sizeChangedEventHandler;
                }
                else
                {
                    border.Loaded -= _borderLoaded;
                    border.SizeChanged -= _sizeChangedEventHandler;
                }
            }
        }

        #endregion

        #region Private Methods

        private static void Border_OnChange(object sender, RoutedEventArgs e, UIElement child)
        {
            if (sender is Border border)
            {
                if (border.ActualWidth > 0 && border.ActualHeight > 0)
                {
                    var rect = new RectangleGeometry();
                    rect.RadiusX = rect.RadiusY = Math.Max(0, border.CornerRadius.TopLeft - border.BorderThickness.Left * .5);
                    rect.Rect = new Rect(child.RenderSize);
                    child.Clip = rect;
                }
            }
        }

        #endregion
    }
}