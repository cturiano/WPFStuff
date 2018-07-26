using System.Windows;
using Microsoft.Win32;

namespace STA_UI
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.ShowDialog(this);
        }

        #endregion
    }
}