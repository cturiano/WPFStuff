using System;
using System.Windows;
using System.Windows.Controls;
using Chat.Controls;

namespace Chat.AttachedProperties
{
    internal class TextEntryWidthMatchProperty : BaseAttachedProperty<TextEntryWidthMatchProperty, bool>
    {
        #region Public Methods

        /// <inheritdoc />
        public override void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Panel panel)
            {                    
                void OnLoaded(object sender, RoutedEventArgs args)
                {
                    panel.Loaded -= OnLoaded;
                    SetWidths(panel);

                    foreach (var child in panel.Children)
                    {
                        switch (child)
                        {
                            case TextEntryControl tec:
                                tec.Label.SizeChanged += (s, ee) => { SetWidths(panel); };
                                break;
                            case PasswordEntryControl pec:
                                pec.Label.SizeChanged += (s, ee) => { SetWidths(panel); };
                                break;
                        }
                    }
                }

                panel.Loaded += OnLoaded;
            }
        }

        #endregion

        #region Private Methods

        private static void SetWidths(Panel panel)
        {
            var maxSize = 0d;
            foreach (var child in panel.Children)
            {
                if (!(child is TextEntryControl) && !(child is PasswordEntryControl))
                    continue;

                var control = (child is TextEntryControl) ? (child as TextEntryControl).Label : (child as PasswordEntryControl).Label;

                maxSize = Math.Max(maxSize, control.RenderSize.Width + control.Margin.Right + control.Margin.Left);
            }

            var gl = new GridLength(maxSize);
            
            foreach (var child in panel.Children)
            {
                switch (child)
                {
                    case TextEntryControl tec:
                        tec.LabelWidth = gl;
                        break;
                    case PasswordEntryControl pec:
                        pec.LabelWidth = gl;
                        break;
                }
            }
        }

        #endregion
    }
}