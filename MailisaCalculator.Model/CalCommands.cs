using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MailisaCalculator.Model
{
    public class CalCommands<T> : ICommand
    {
        private Action<T> _execute;
        private Func<bool> _canExecute;
        public CalCommands (Action<T> execute, Func<bool> canExecute) 
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged= delegate { };

        public bool CanExecute(object parameter)
        {
            return _canExecute is null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
