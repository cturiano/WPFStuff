using System.Windows;
using Chat.ViewModels;

namespace Chat.Views
{
    /// <inheritdoc cref="Window" />
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DialogWindow
    {
        #region Fields

        private DialogViewModel _viewModel;

        #endregion

        #region Constructors

        public DialogWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public DialogViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                DataContext = _viewModel;
            }
        }

        #endregion
    }
}