using System.Windows;
using System.Windows.Controls;

namespace Chat.Controls
{
    public abstract class BaseEntryControl : UserControl
    {
        #region Static Fields and Constants

        public static readonly DependencyProperty LabelWidthProperty = DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(BaseEntryControl), new PropertyMetadata(GridLength.Auto, LabelWidthChangedCallBack));

        #endregion

        #region Properties

        public GridLength LabelWidth
        {
            get => (GridLength)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }

        #endregion

        #region Protected Methods

        protected static void LabelWidthChangedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null && d is TextEntryControl tec)
            {
                tec.LabelColumnDefinition.Width = (GridLength)e.NewValue;
            }
            else if (e.NewValue != null && d is PasswordEntryControl pec)
            {
                pec.LabelColumnDefinition.Width = (GridLength)e.NewValue;
            }
        }

        #endregion
    }
}