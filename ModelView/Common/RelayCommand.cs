using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;

namespace ViewModel
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action _action;
        Predicate<object> _predicate;
        public RelayCommand(Action action, Predicate<object> predicate)
        {
            _action = action;
            _predicate = predicate;
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, null);
        }

        public bool CanExecute(object parameter)
        {
            if (_predicate != null)
            {
                return _predicate(parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            _action.Invoke();
        }
    }

    public class RelayCommandObj : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action<object> _action;
        Predicate<object> _predicate;
        public RelayCommandObj(Action<object> action, Predicate<object> predicate)
        {
            _action = action;
            _predicate = predicate;
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, null);
        }

        public bool CanExecute(object parameter)
        {
            if (_predicate != null)
            {
                return _predicate(parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            _action.Invoke(parameter);
        }
    }
}
