using System;
using System.Windows.Input;

namespace WpfTreeViews
{
    internal class RelayCommand : ICommand
    {
        #region Fields

        private readonly Action _action;

        #endregion

        #region Constructors

        public RelayCommand(Action action)
        {
            _action = action;
        }

        #endregion

        #region Events and Delegates

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Public Methods

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _action.Invoke();
        }

        #endregion
    }
}