using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Chat.Core.Models;
using Chat.Core.ViewModels;
using Chat.Extensions;

namespace Chat.Views
{
    /// <inheritdoc cref="BasePage{TViewModel}" />
    /// <summary>
    ///     Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class ChatPage
    {
        #region Constructors

        public ChatPage(ChatMessageListViewModel viewModel) : base(viewModel)
        {
            Init();
        }

        public ChatPage()
        {
            Init();
        }

        #endregion

        #region Protected Methods

        /// <inheritdoc />
        protected override void OnViewModelChanged()
        {
            if (ChatMessageList != null)
            {
                var storyboard = new Storyboard();
                storyboard.AddFadeIn(1);
                storyboard.Begin(ChatMessageList);
                MessageText.Focus();
            }
        }

        #endregion

        #region Private Methods

        private void Init()
        {
            InitializeComponent();
            PageType = ApplicationPage.Chat;
        }

        private void MessageText_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (sender is TextBox textbox)
            {
                if (e.Key == Key.Enter || e.Key == Key.Return)
                {
                    if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
                    {
                        var index = textbox.CaretIndex;
                        textbox.Text += Environment.NewLine;
                        textbox.CaretIndex = index + Environment.NewLine.Length;
                    }
                    else
                    {
                        ViewModel.SendCommand.Execute(null);
                    }

                    e.Handled = true;
                }
            }
        }

        #endregion
    }
}