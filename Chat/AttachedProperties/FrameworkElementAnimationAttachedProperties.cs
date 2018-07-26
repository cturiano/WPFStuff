using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Chat.Animations;

namespace Chat.AttachedProperties
{
    internal abstract class AnimateBaseProperty<TParent> : BaseAttachedProperty<TParent, bool> where TParent : BaseAttachedProperty<TParent, bool>, new()
    {
        #region Properties

        public bool FirstLoad { get; set; } = true;

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public override void OnValueUpdated(DependencyObject d, object value)
        {
            if (d is FrameworkElement element)
            {
                if (element.GetValue(ValueProperty) != value || FirstLoad)
                {
                    if (FirstLoad)
                    {
                        void OnLoaded(object ss, RoutedEventArgs ee)
                        {
                            element.Loaded -= OnLoaded;
                            DoAnimation(element, (bool)value);
                            FirstLoad = false;
                        }

                        element.Loaded += OnLoaded;
                    }
                    else
                    {
                        DoAnimation(element, (bool)value);
                    }
                }
            }
        }

        #endregion

        #region Protected Methods

        protected virtual void DoAnimation(FrameworkElement element, bool value)
        {
        }

        #endregion
    }

    internal class AnimateFadeInImageOnLoadProperty : AnimateBaseProperty<AnimateFadeInImageOnLoadProperty>
    {
        #region Public Methods

        /// <inheritdoc />
        public override void OnValueUpdated(DependencyObject d, object value)
        {
            if (d is Image image)
            {
                if ((bool)value)
                {
                    image.TargetUpdated += Image_TargetUpdatedAsync;
                }
                else
                {
                    image.TargetUpdated -= Image_TargetUpdatedAsync;
                }
            }
        }

        #endregion

        #region Private Methods

        private static async void Image_TargetUpdatedAsync(object sender, DataTransferEventArgs e)
        {
            if (sender is Image image && e.Property.Name == "Source")
            {
                await image.FadeInAsync(9f);
            }
        }

        #endregion
    }

    internal class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        #region Protected Methods

        /// <inheritdoc />
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                await element.SlideAndFadeInFromLeftAsync(FirstLoad ? 0 : 0.3f, false);
            }
            else
            {
                await element.SlideAndFadeOutToLeftAsync(FirstLoad ? 0 : 0.3f, false);
            }
        }

        #endregion
    }

    internal class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty>
    {
        #region Protected Methods

        /// <inheritdoc />
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                await element.SlideAndFadeUpFromBottomAsync(FirstLoad ? 0 : 0.3f, false);
            }
            else
            {
                await element.SlideAndFadeDownToBottomAsync(FirstLoad ? 0 : 0.3f, false);
            }
        }

        #endregion
    }

    internal class AnimateSlideInFromBottomOnceProperty : AnimateBaseProperty<AnimateSlideInFromBottomOnceProperty>
    {
        #region Protected Methods

        /// <inheritdoc />
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                await element.SlideAndFadeUpFromBottomAsync(0.3f, false);
            }
        }

        #endregion
    }

    internal class AnimateSlideInFromBottomMarginProperty : AnimateBaseProperty<AnimateSlideInFromBottomMarginProperty>
    {
        #region Protected Methods

        /// <inheritdoc />
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                await element.SlideAndFadeUpFromBottomAsync(FirstLoad ? 0 : 0.3f);
            }
            else
            {
                await element.SlideAndFadeDownToBottomAsync(FirstLoad ? 0 : 0.3f);
            }
        }

        #endregion
    }

    internal class AnimateFadeInProperty : AnimateBaseProperty<AnimateFadeInProperty>
    {
        #region Protected Methods

        /// <inheritdoc />
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                await element.FadeInAsync(0.3f);
            }
            else
            {
                await element.FadeOutAsync(0.3f);
            }
        }

        #endregion
    }
}