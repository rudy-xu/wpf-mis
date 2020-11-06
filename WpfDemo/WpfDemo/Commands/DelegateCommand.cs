using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfDemo.Commands
{
    class DelegateCommand : ICommand
    {
        #region Fields
        private Action<Object> _Execute { get; set; }
        private Func<Object, bool> _CanExecute { get; set; }
        #endregion  //Fields

        #region Constructors
        public DelegateCommand(Action<Object> execute) : this(execute, null) { }

        public DelegateCommand(Action<Object> execute, Func<Object, bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentException("execute exception");
            }

            _Execute = execute;
            _CanExecute = canExecute;
        }
        #endregion  //Constructors

        #region ICommand Members
        public event EventHandler CanExecuteChanged
        {
            add 
            {
                if (_CanExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove 
            {
                if (_CanExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            return _CanExecute == null ? true : _CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (this._Execute == null)
            {
                return;
            }
            this._Execute(parameter);
        }
        #endregion  //ICommand Members
    }
}
