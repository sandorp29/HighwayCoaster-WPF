using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFZH.Helpers
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add
            {
                //ha valaki feliratkozik
                CommandManager.RequerySuggested += value;
                this.CanExecuteChangedInternal += value;
            }
            remove
            {
                //ha valaki leiratkozik
                CommandManager.RequerySuggested -= value;
                this.CanExecuteChangedInternal -= value;
            }
        }


        private event EventHandler CanExecuteChangedInternal;

        Action<object> execute_function; //void(object)
        Predicate<object> canexecute_function; //bool(object)


        public RelayCommand(Action<object> execute_function,
            Predicate<object> canexecute_function)
        {
            this.execute_function = execute_function ??
                throw new ArgumentException("execute function not defined!");

            this.canexecute_function = canexecute_function ??
                throw new ArgumentException("can execute function not defined!");
        }

        //ha nem adunk meg canexecute-ot
        //akkor úgy vesszük hogy bármikor futhat a command
        public RelayCommand(Action<object> execute_function)
            : this(execute_function, t => true)
        {

        }

        public bool CanExecute(object parameter)
        {
            return this.canexecute_function != null
                && this.canexecute_function(parameter);
        }

        public void Execute(object parameter)
        {
            execute_function?.Invoke(parameter);
        }

        public void OnCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChangedInternal;

            handler?.Invoke(this, EventArgs.Empty);
        }

        public void Destroy()
        {
            this.canexecute_function = t => false;
            this.execute_function = t => { return; };
        }
    }
    
}
