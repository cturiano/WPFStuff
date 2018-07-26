using System.Threading.Tasks;
using System.Windows.Threading;
using Chat.Core.ViewModels;

namespace Chat.Core.Interfaces
{
    public interface IUIManager
    {
        #region Public Methods

        Task ShowMessageBox(MessageBoxViewModel viewModel);

        #endregion
    }
}