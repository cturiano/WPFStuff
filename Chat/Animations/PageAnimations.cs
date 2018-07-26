using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Chat.Extensions;

namespace Chat.Animations
{
    public static class PageAnimations
    {
        #region Public Methods

        public static async Task SlideAndFadeInFromRightAsync(this Page page, float duration)
        {
            var sb = new Storyboard();
            sb.AddSlideRightIn(duration, page.WindowWidth, .9f);
            sb.AddFadeIn(duration);
            sb.Begin(page);
            page.Visibility = Visibility.Visible;
            await Task.Delay(TimeSpan.FromSeconds(duration));
        }

        public static async Task SlideAndFadeOutToLeftAsync(this Page page, float duration)
        {
            var sb = new Storyboard();
            sb.AddSlideLeftOut(duration, page.WindowWidth, .9f);
            sb.AddFadeOut(duration);
            sb.Begin(page);
            page.Visibility = Visibility.Visible;
            await Task.Delay(TimeSpan.FromSeconds(duration));
        }

        #endregion
    }
}