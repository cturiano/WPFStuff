using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Chat.Converters;
using Chat.Core.Models;
using Chat.Core.ViewModels;
using Chat.Views;

namespace Chat.Controls
{
    /// <inheritdoc cref="UserControl" />
    /// <summary>
    ///     Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost
    {
        #region Static Fields and Constants

        public static readonly DependencyProperty CurrentPageProperty = DependencyProperty.Register(nameof(CurrentPage), typeof(ApplicationPage), typeof(PageHost), new UIPropertyMetadata(default(ApplicationPage), null, CurrentPagePropertyChanged));

        public static readonly DependencyProperty CurrentViewModelProperty = DependencyProperty.Register(nameof(CurrentViewModel), typeof(BaseViewModel), typeof(PageHost), new UIPropertyMetadata());

        #endregion

        #region Constructors

        public PageHost()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                NewPage.Content = (BasePage)new ApplicationPageValueConverter().Convert(Core.IOC.IoC.Get<ApplicationViewModel>().CurrentPage);
            }
        }

        #endregion

        #region Properties

        public ApplicationPage CurrentPage
        {
            get => (ApplicationPage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        public BaseViewModel CurrentViewModel
        {
            get => (BaseViewModel)GetValue(CurrentViewModelProperty);
            set => SetValue(CurrentViewModelProperty, value);
        }

        #endregion

        #region Private Methods

        private static object CurrentPagePropertyChanged(DependencyObject d, object value)
        {
            if (d is PageHost pageHost)
            {
                var newFrame = pageHost.NewPage;
                var oldFrame = pageHost.OldPage;

                var currentPage = (ApplicationPage)d.GetValue(CurrentPageProperty);
                var currentViewModel = (BaseViewModel)d.GetValue(CurrentViewModelProperty);

                if (newFrame.Content is BasePage page &&
                    page.PageType == currentPage)
                {
                    // Just update the view model
                    page.ViewModelObject = currentViewModel;
                    return value;
                }

                var oldPageContent = newFrame.Content;
                newFrame.Content = null;
                oldFrame.Content = oldPageContent;

                if (oldPageContent is BasePage oldPage)
                {
                    oldPage.ShouldAnimateOut = true;
                    Task.Delay((int)Math.Ceiling(oldPage.AnimationDuration) * 1000).ContinueWith(t => { Application.Current.Dispatcher.Invoke(() => oldPage.Content = null); });
                }

                newFrame.Content = new ApplicationPageValueConverter().Convert(currentPage, null, currentViewModel);
            }

            return value;
        }
              
        #endregion
    }
}