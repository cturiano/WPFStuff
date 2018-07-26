using System.Threading.Tasks;
using System.Windows.Threading;
using Chat.Controls;
using Chat.Core.Interfaces;
using Chat.Core.ViewModels;

namespace Chat.IoC
{
    internal class UIManager : IUIManager
    {
        #region Public Methods

        /// <inheritdoc cref="IUIManager" />
        public async Task ShowMessageBox(MessageBoxViewModel viewModel)
        {
            await new MessageBoxDialog().ShowDialog(viewModel);
        }

        #endregion
    }
}