using System;
using System.Windows.Input;

namespace WpfTreeViews
{
    internal class ParameterizedRelayCommand : ICommand
    {
        #region Fields

        private readonly Action<object> _action;

        #endregion

        #region Constructors

        public ParameterizedRelayCommand(Action<object> action) => _action = action;

        #endregion

        #region Events and Delegates

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Public Methods

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _action.Invoke(parameter);
        }

        #endregion
    }
}