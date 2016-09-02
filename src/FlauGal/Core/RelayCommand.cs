using System;

namespace FlauGal.Core
{
    /// <summary>
    /// Class to easy create ICommands
    /// </summary>
    public class RelayCommand : TypedRelayCommand<object>
    {
        public RelayCommand(Action<object> methodToExecute, Func<object, bool> canExecuteEvaluator = null)
            : base(methodToExecute, canExecuteEvaluator)
        {
        }
    }
}
