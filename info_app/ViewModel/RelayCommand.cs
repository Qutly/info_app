using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace info_app.ViewModel
{
    /// <summary>
    /// Implementacja interfejsu ICommand, która reprezentuje polecenie, które można wykonać.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _executeAction; // Pole przechowujące delegata Action<object>, który będzie wykonywany, gdy komenda zostanie wykonana.
        private readonly Predicate<object> _predicate; // Pole przechowujące delegata Predicate<object>, który określa, czy komenda może zostać wykonana w danym momencie.

        /// <summary>
        /// Konstruktor RelayCommand.
        /// </summary>
        /// <param name="executeAction">Delegat Action&lt;object&gt; reprezentujący akcję do wykonania, gdy komenda zostanie wykonana.</param>
        public RelayCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _predicate = null;
        }

        /// <summary>
        /// Konstruktor RelayCommand.
        /// </summary>
        /// <param name="executeAction">Delegat Action&lt;object&gt; reprezentujący akcję do wykonania, gdy komenda zostanie wykonana.</param>
        /// <param name="predicate">Delegat Predicate&lt;object&gt; określający, czy komenda może być wykonana w danym momencie.</param>
        public RelayCommand(Action<object> executeAction, Predicate<object> predicate)
        {
            _executeAction = executeAction;
            _predicate = predicate;
        }

        /// <summary>
        /// Zdarzenie CanExecuteChanged, które występuje, gdy zmienia się możliwość wykonania komendy.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Metoda określająca, czy komenda może zostać wykonana.
        /// </summary>
        /// <param name="parameter">Parametr przekazywany do komendy.</param>
        /// <returns>Prawda, jeśli komenda może zostać wykonana; w przeciwnym razie fałsz.</returns>
        public bool CanExecute(object parameter)
        {
            return _predicate == null ? true : _predicate(parameter);
        }

        /// <summary>
        /// Metoda wykonująca polecenie.
        /// </summary>
        /// <param name="parameter">Parametr przekazywany do komendy.</param>
        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }
}
