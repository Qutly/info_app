using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace info_app.ViewModel
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _executeAction; //pole przechowujące delegata Action<object>, który będzie wykonywany, gdy komenda zostanie wykonana.
        private readonly Predicate<object> _predicate; //pole przechowujące delegata Predicate<object>, który określa, czy komenda może zostać wykonana w danym momencie.

        //konstruktory
        /*
        Pierwszy konstruktor przyjmuje delegata Action<object>, który reprezentuje akcję do wykonania, gdy komenda zostanie wykonana. 
        Drugi konstruktor przyjmuje również delegata Predicate<object>, który określa warunek, czy komenda może być wykonywana w danym momencie.
         */
        public RelayCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _predicate = null;
        }
        public RelayCommand(Action<object> executeAction, Predicate<object> predicate) 
        {
            _executeAction = executeAction;
            _predicate = predicate;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value;  }
            remove {  CommandManager.RequerySuggested -= value;}
        }

        public bool CanExecute(object parameter)
        {
            return _predicate == null ? true : _predicate(parameter);
        }

        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }
}
