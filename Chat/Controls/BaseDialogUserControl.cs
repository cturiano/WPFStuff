using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Chat.Core.Infrastructure;
using Chat.Core.ViewModels;
using Chat.ViewModels;
using Chat.Views;

namespace Chat.Controls
{
    /// <inheritdoc cref="UserControl" />
    public class BaseDialogUserControl : UserControl
    {
        #region Fields

        private readonly DialogWindow _dialogWindow;

        #endregion

        #region Constructors

        public BaseDialogUserControl()
        {
            _dialogWindow = new DialogWindow();
            _dialogWindow.ViewModel = new DialogViewModel(_dialogWindow);
        }

        #endregion

        #region Properties

        public ICommand CloseCommand => new RelayCommand(() => _dialogWindow.Close());

        public int TitleHeight { get; set; } = 30;

        public int WindowMinimumHeight { get; set; } = 100;

        public int WindowMinimumWidth { get; set; } = 250;

        #endregion

        #region Public Methods

        public async Task<DispatcherOperation> ShowDialog<T>(T viewModel) where T : BaseDialogViewModel
        {
            return Application.Current.Dispatcher.InvokeAsync(() =>
                                                             {
                                                                 _dialogWindow.ViewModel.WindowMinimumHeight = WindowMinimumHeight;
                                                                 _dialogWindow.ViewModel.WindowMinimumWidth = WindowMinimumWidth;
                                                                 _dialogWindow.ViewModel.TitleHeight = TitleHeight;
                                                                 _dialogWindow.ViewModel.Title = string.IsNullOrEmpty(((dynamic)viewModel).Title) ? _dialogWindow.Title : ((dynamic)viewModel).Title;
                                                                 _dialogWindow.ViewModel.Content = this;

                                                                 DataContext = viewModel;

                                                                 _dialogWindow.Owner = Application.Current.MainWindow;
                                                                 _dialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                                                                 _dialogWindow.ShowDialog();
                                                             });
        }

        #endregion
    }
}