using System.Windows;
using System.Windows.Input;
using Chat.Core.Infrastructure;
using Chat.Core.ViewModels;
using Chat.Views;
using Point = System.Windows.Point;

namespace Chat.ViewModels
{
    public class WindowViewModel : BaseViewModel
    {
        #region Fields

        private readonly WindowDockPosition _dockPosition = WindowDockPosition.Undocked;
        private readonly Window _window;
        private int _outerMarginSize = 4;
        private int _windowRadius = 10;

        #endregion

        #region Constructors

        public WindowViewModel(Window window)
        {
            _window = window;
            _window.StateChanged += (sender, e) =>
                                    {
                                        OnPropertyChanged(nameof(ResizeBorderThickness));
                                        OnPropertyChanged(nameof(OuterMarginSizeThickness));
                                        OnPropertyChanged(nameof(OuterMarginSize));
                                        OnPropertyChanged(nameof(WindowRadius));
                                        OnPropertyChanged(nameof(WindowCornerRadius));
                                    };

            new WindowResizer(_window);
        }

        #endregion

        #region Properties

        public bool Borderless => _window.WindowState == WindowState.Maximized || _dockPosition != WindowDockPosition.Undocked;

        public ICommand CloseCommand => new RelayCommand(() => _window.Close());

        public bool DimmableOverlayVisible { get; set; }

        public int InnerContentSize { get; set; } = 0;

        public Thickness InnerContentThickness => new Thickness(InnerContentSize);

        public ICommand MaximizeCommand => new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);

        public ICommand MenuCommand => new RelayCommand(() => SystemCommands.ShowSystemMenu(_window, GetMousePosition()));

        public ICommand MinimizeCommand => new RelayCommand(() => _window.WindowState = WindowState.Minimized);

        public int OuterMarginSize
        {
            get => _window.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;
            set => _outerMarginSize = value;
        }

        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);

        public int ResizeBorder => _window.WindowState == WindowState.Maximized ? 0 : 4;

        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);
               
        public int TitleHeight { get; set; } = 32;

        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        public int WindowMinimumHeight { get; set; } = 600;

        public int WindowMinimumWidth { get; set; } = 800;

        public int WindowRadius
        {
            get => _window.WindowState == WindowState.Maximized ? 0 : _windowRadius;
            set => _windowRadius = value;
        }

        #endregion

        #region Private Methods

        private Point GetMousePosition()
        {
            Mouse.Capture(_window);
            var pointToWindow = Mouse.GetPosition(_window);
            Mouse.Capture(null);
            return _window.PointToScreen(pointToWindow);
        }

        #endregion
    }
}