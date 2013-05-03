using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MultiCrono.Commands
{
    public class DelegateCommand : ICommand
    {

        private Action execute;
        public Func<bool> canExecute { get; set; }

        public DelegateCommand(Action exec, Func<bool> canExec )
        {
            this.execute = exec;
            this.canExecute = canExec;
        }

        public DelegateCommand(Action exec)
        {
            this.execute = exec;
            this.canExecute = () => true;
        }
        
        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
                return true;

            return canExecute();
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (execute != null)
                execute();
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged!=null) 
                CanExecuteChanged(null, new EventArgs());
        }

    }
}
