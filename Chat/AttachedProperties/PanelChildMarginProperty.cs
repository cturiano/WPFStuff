using System.Windows;
using System.Windows.Controls;

namespace Chat.AttachedProperties
{
    internal class PanelChildMarginProperty : BaseAttachedProperty<PanelChildMarginProperty, string>
    {
        #region Public Methods

        /// <inheritdoc />
        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Panel panel)
            {
                panel.Loaded += (sender, args) =>
                                {
                                    foreach (FrameworkElement child in panel.Children)
                                    {
                                        var thickness = new ThicknessConverter().ConvertFromString(e.NewValue as string);
                                        if (thickness != null && thickness is Thickness t)
                                        {
                                            child.Margin = t;
                                        }
                                    }
                                };
            }
        }

        #endregion
    }
}