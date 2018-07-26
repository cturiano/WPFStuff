using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Chat.Animations;
using Chat.Core.Models;
using Chat.Core.ViewModels;

namespace Chat.Views
{
    public class BasePage : ContentControl
    {
        #region Fields

        private object _viewModel;

        #endregion

        #region Constructors

        public BasePage()
        {
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }

            if (PageLoadAnimation == PageAnimation.None)
            {
                Visibility = Visibility.Collapsed;
            }

            Loaded += Page_LoadedAsync;
            //Unloaded += Page_UnloadAsync;
        }

        #endregion

        #region Properties

        public float AnimationDuration { get; set; } = .5f;

        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public ApplicationPage PageType { get; protected set; }

        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        public bool ShouldAnimateOut { get; set; }

        public object ViewModelObject
        {
            get => _viewModel;
            set
            {
                if (_viewModel != value)
                {
                    _viewModel = value;
                    DataContext = _viewModel;
                    OnViewModelChanged();
                }
            }
        }

        #endregion

        #region Public Methods

        public async Task AnimateLoadAsync()
        {
            if (PageLoadAnimation != PageAnimation.None)
            {
                switch (PageLoadAnimation)
                {
                    case PageAnimation.SlideAndFadeInFromRight:
                        await this.SlideAndFadeInFromRightAsync(AnimationDuration);
                        break;
                }
            }
        }

        public async Task AnimateUnloadAsync()
        {
            if (PageUnloadAnimation != PageAnimation.None)
            {
                switch (PageUnloadAnimation)
                {
                    case PageAnimation.SlideAndFadeOutToLeft:
                        await this.SlideAndFadeOutToLeftAsync(AnimationDuration);
                        break;
                }
            }
        }

        #endregion

        #region Protected Methods

        protected virtual void OnViewModelChanged()
        {
        }

        #endregion

        #region Private Methods

        private async void Page_LoadedAsync(object sender, RoutedEventArgs e)
        {
            if (ShouldAnimateOut)
            {
                await AnimateUnloadAsync();
            }
            else
            {
                await AnimateLoadAsync();
            }
        }

        private async void Page_UnloadAsync(object sender, RoutedEventArgs e)
        {
            await AnimateUnloadAsync();
        }

        #endregion
    }

    public class BasePage<TViewModel> : BasePage where TViewModel : BaseViewModel, new()
    {
        #region Constructors

        public BasePage(TViewModel viewModel = null) => ViewModel = viewModel ?? Core.IOC.IoC.Get<TViewModel>();

        public BasePage() => ViewModel = Core.IOC.IoC.Get<TViewModel>();

        #endregion

        #region Properties

        public TViewModel ViewModel
        {
            get => (TViewModel)ViewModelObject;
            set => ViewModelObject = value;
        }

        #endregion
    }
}