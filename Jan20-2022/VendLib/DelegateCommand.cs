using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VendLib
{
    public class DelegateCommand <T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Predicate<T> _canExecute;


        public DelegateCommand(Action<T> execute, Predicate<T> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }


        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged is not null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
            
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute is null || _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
