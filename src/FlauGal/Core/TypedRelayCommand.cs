using System;
using System.Diagnostics;
using System.Windows.Input;

namespace FlauGal.Core
{
    /// <summary>
    /// Class to easy create ICommands with casting the command parameter to the desired type
    /// </summary>
    public class TypedRelayCommand<T> : ICommand
    {
        private readonly Action<T> _methodToExecute;
        readonly Func<T, bool> _canExecuteEvaluator;

        public TypedRelayCommand(Action<T> methodToExecute, Func<T, bool> canExecuteEvaluator = null)
        {
            _methodToExecute = methodToExecute;
            _canExecuteEvaluator = canExecuteEvaluator;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecuteEvaluator == null || _canExecuteEvaluator.Invoke((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _methodToExecute.Invoke((T)parameter);
        }
    }
}
