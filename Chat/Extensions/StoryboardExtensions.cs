using System;
using System.Windows;
using System.Windows.Media.Animation;
using Chat.Animations;

namespace Chat.Extensions
{
    public static class StoryboardExtensions
    {
        #region Public Methods

        public static void AddFadeIn(this Storyboard storyboard, float duration)
        {
            AddFade(storyboard, duration, 0, 1);
        }

        public static void AddFadeOut(this Storyboard storyboard, float duration)
        {
            AddFade(storyboard, duration, 1, 0);
        }

        public static void AddSlideBottomDown(this Storyboard storyboard, float duration, double offset, float deceleration = 0f, bool keepMargin = true)
        {
            AddSlide(storyboard, MakeThicknessAnimation(duration, offset, deceleration, AnimationSlideLocation.Bottom, AnimationSlideDirection.Down, keepMargin));
        }

        public static void AddSlideBottomUp(this Storyboard storyboard, float duration, double offset, float deceleration = 0f, bool keepMargin = true)
        {
            AddSlide(storyboard, MakeThicknessAnimation(duration, offset, deceleration, AnimationSlideLocation.Bottom, AnimationSlideDirection.Up, keepMargin));
        }

        public static void AddSlideLeftIn(this Storyboard storyboard, float duration, double offset, float deceleration = 0f, bool keepMargin = true)
        {
            AddSlide(storyboard, MakeThicknessAnimation(duration, offset, deceleration, AnimationSlideLocation.Left, AnimationSlideDirection.In, keepMargin));
        }

        public static void AddSlideLeftOut(this Storyboard storyboard, float duration, double offset, float deceleration = 0f, bool keepMargin = true)
        {
            AddSlide(storyboard, MakeThicknessAnimation(duration, offset, deceleration, AnimationSlideLocation.Left, AnimationSlideDirection.Out, keepMargin));
        }

        public static void AddSlideRightIn(this Storyboard storyboard, float duration, double offset, float deceleration = 0f, bool keepMargin = true)
        {
            AddSlide(storyboard, MakeThicknessAnimation(duration, offset, deceleration, AnimationSlideLocation.Right, AnimationSlideDirection.In, keepMargin));
        }

        public static void AddSlideRightOut(this Storyboard storyboard, float duration, double offset, float deceleration = 0f, bool keepMargin = true)
        {
            AddSlide(storyboard, MakeThicknessAnimation(duration, offset, deceleration, AnimationSlideLocation.Right, AnimationSlideDirection.Out, keepMargin));
        }

        public static void AddSlideTopDown(this Storyboard storyboard, float duration, double offset, float deceleration = 0f, bool keepMargin = true)
        {
            AddSlide(storyboard, MakeThicknessAnimation(duration, offset, deceleration, AnimationSlideLocation.Top, AnimationSlideDirection.Down, keepMargin));
        }

        public static void AddSlideTopUp(this Storyboard storyboard, float duration, double offset, float deceleration = 0f, bool keepMargin = true)
        {
            AddSlide(storyboard, MakeThicknessAnimation(duration, offset, deceleration, AnimationSlideLocation.Top, AnimationSlideDirection.Up, keepMargin));
        }

        #endregion

        #region Private Methods

        private static void AddFade(TimelineGroup storyboard, float duration, int from, int to)
        {
            var animation = new DoubleAnimation
                            {
                                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                                From = from,
                                To = to
                            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyboard.Children.Add(animation);
        }

        private static void AddSlide(TimelineGroup storyboard, Timeline thicknessAnimation)
        {
            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            storyboard.Children.Add(thicknessAnimation);
        }

        private static ThicknessAnimation MakeThicknessAnimation(float duration, double offset, float deceleration, AnimationSlideLocation location, AnimationSlideDirection direction, bool keepMargin)
        {
            var from = new Thickness();
            var to = new Thickness();

            switch (location)
            {
                case AnimationSlideLocation.Left:
                    switch (direction)
                    {
                        case AnimationSlideDirection.In:
                            from = new Thickness(-offset, 0, keepMargin ? offset : 0, 0);
                            to = new Thickness(0);
                            break;
                        case AnimationSlideDirection.Out:
                            from = new Thickness(0);
                            to = new Thickness(-offset, 0, keepMargin ? offset : 0, 0);
                            break;
                    }

                    break;
                case AnimationSlideLocation.Right:
                    switch (direction)
                    {
                        case AnimationSlideDirection.In:
                            from = new Thickness(keepMargin ? offset : 0, 0, -offset, 0);
                            to = new Thickness(0);
                            break;
                        case AnimationSlideDirection.Out:
                            from = new Thickness(0);
                            to = new Thickness(keepMargin ? offset : 0, 0, -offset, 0);
                            break;
                    }

                    break;
                case AnimationSlideLocation.Top:
                    switch (direction)
                    {
                        case AnimationSlideDirection.Down:
                            from = new Thickness(0, -offset, 0, keepMargin ? offset : 0);
                            to = new Thickness(0);
                            break;
                        case AnimationSlideDirection.Up:
                            from = new Thickness(0);
                            to = new Thickness(0, -offset, 0, keepMargin ? offset : 0);
                            break;
                    }

                    break;
                case AnimationSlideLocation.Bottom:
                    switch (direction)
                    {
                        case AnimationSlideDirection.Down:
                            from = new Thickness(0);
                            to = new Thickness(0, keepMargin ? offset : 0, 0, -offset);
                            break;
                        case AnimationSlideDirection.Up:
                            from = new Thickness(0, keepMargin ? offset : 0, 0, -offset);
                            to = new Thickness(0);
                            break;
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            return new ThicknessAnimation
                   {
                       Duration = new Duration(TimeSpan.FromSeconds(duration)),
                       From = from,
                       To = to,
                       DecelerationRatio = deceleration
                   };
        }

        #endregion
    }
}