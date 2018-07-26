using System.Windows;
using WpfTreeViews.ViewModels;

namespace WpfTreeViews
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
            DataContext = new DirectoryViewModel();
        }

        #endregion
    }
}