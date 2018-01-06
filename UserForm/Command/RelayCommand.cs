using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UserForm.Command
{
    public class RelayCommand : ICommand
    {
        Action<object> executeAction;
        Func<object, bool> canExecute;
        bool canExecuteCache;  // To grey out the Update button


        public RelayCommand(Action<object> executeAction, Func<object, bool> canExecute, bool canExecuteCache)
        {
            this.executeAction = executeAction;
            this.canExecute = canExecute;
            canExecuteCache = canExecuteCache;
                
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
            {
                return true;
            }
            else
            {
                return canExecute(parameter);
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }


        public void Execute(object parameter)
        {
            executeAction(parameter);
        }
    }
}
