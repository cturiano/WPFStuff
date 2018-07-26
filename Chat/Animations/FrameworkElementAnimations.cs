using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using Chat.Extensions;

namespace Chat.Animations
{
    public static class FrameworkElementAnimations
    {
        #region Public Methods

        public static async Task FadeInAsync(this FrameworkElement element, float duration)
        {
            var sb = new Storyboard();
            sb.AddFadeIn(duration);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay(TimeSpan.FromSeconds(duration));
        }

        public static async Task FadeOutAsync(this FrameworkElement element, float duration)
        {
            var sb = new Storyboard();
            sb.AddFadeOut(duration);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay(TimeSpan.FromSeconds(duration));
            element.Visibility = Visibility.Collapsed;
        }

        public static async Task SlideAndFadeDownToBottomAsync(this FrameworkElement element, float duration, bool keepMargin = true, int height = 0)
        {
            var sb = new Storyboard();
            sb.AddSlideBottomDown(duration, height == 0 ? element.ActualHeight : height, .9f, keepMargin);
            sb.AddFadeOut(duration);

            await DoAnimation(element, duration, sb);
            element.Visibility = Visibility.Hidden;
        }

        public static async Task SlideAndFadeInFromLeftAsync(this FrameworkElement element, float duration, bool keepMargin = true, int width = 0)
        {
            var sb = new Storyboard();
            sb.AddSlideLeftIn(duration, width == 0 ? element.ActualWidth : width, .9f, keepMargin);
            sb.AddFadeIn(duration);

            await DoAnimation(element, duration, sb);
        }

        public static async Task SlideAndFadeInFromRightAsync(this FrameworkElement element, float duration, bool keepMargin = true, int width = 0)
        {
            var sb = new Storyboard();
            sb.AddSlideRightIn(duration, width == 0 ? element.ActualWidth : width, .9f, keepMargin);
            sb.AddFadeIn(duration);

            await DoAnimation(element, duration, sb);
        }

        public static async Task SlideAndFadeOutToLeftAsync(this FrameworkElement element, float duration, bool keepMargin = true, int width = 0)
        {
            var sb = new Storyboard();
            sb.AddSlideLeftOut(duration, width == 0 ? element.ActualWidth : width, .9f, keepMargin);
            sb.AddFadeOut(duration);

            await DoAnimation(element, duration, sb);
            element.Visibility = Visibility.Hidden;
        }

        public static async Task SlideAndFadeOutToRightAsync(this FrameworkElement element, float duration, bool keepMargin = true, int width = 0)
        {
            var sb = new Storyboard();
            sb.AddSlideRightOut(duration, width == 0 ? element.ActualWidth : width, .9f, keepMargin);
            sb.AddFadeOut(duration);

            await DoAnimation(element, duration, sb);
            element.Visibility = Visibility.Hidden;
        }

        public static async Task SlideAndFadeUpFromBottomAsync(this FrameworkElement element, float duration, bool keepMargin = true, int height = 0)
        {
            var sb = new Storyboard();
            sb.AddSlideBottomUp(duration, height == 0 ? element.ActualHeight : height, .9f, keepMargin);
            sb.AddFadeIn(duration);

            await DoAnimation(element, duration, sb);
        }

        #endregion

        #region Private Methods

        private static async Task DoAnimation(FrameworkElement element, float duration, Storyboard storyboard)
        {
            storyboard.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay(TimeSpan.FromSeconds(duration));
        }

        #endregion
    }
}