using System;
using System.Windows;
using Chat.ViewModels;

namespace Chat.Views
{
    /// <inheritdoc cref="Window" />
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new WindowViewModel(this);
        }

        #endregion

        #region Private Methods

        private void AppWindow_Activated(object sender, EventArgs e)
        {
            (DataContext as WindowViewModel).DimmableOverlayVisible = false;
        }

        private void AppWindow_Deactivated(object sender, EventArgs e)
        {
            (DataContext as WindowViewModel).DimmableOverlayVisible = true;
        }

        #endregion
    }
}