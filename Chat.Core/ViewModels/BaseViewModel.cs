using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Chat.Core.Extensions;
using PropertyChanged;

namespace Chat.Core.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Events and Delegates

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #endregion

        #region Public Methods

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region Protected Methods

        protected async Task RunCommand(Expression<Func<bool>> expression, Func<Task> action)
        {
            if (!expression.GetPropertyValue())
            {
                expression.SetPropertyValue(true);

                try
                {
                    await action.Invoke();
                }
                finally
                {
                    expression.SetPropertyValue(false);
                }
            }
        }

        #endregion
    }
}