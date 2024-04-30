using info_app.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Windows.Markup;
using info_app.API;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using info_app.Views;
using System.Windows;

namespace info_app.ViewModel
{
    /// <summary>
    /// Klasa ViewModelu głównego widoku.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentChildView;
        private int _UserId;

        /// <summary>
        /// ID użytkownika.
        /// </summary>
        public int UserId
        {
            get { return _UserId; }
            set
            {
                _UserId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }

        /// <summary>
        /// Aktualny widok podrzędny.
        /// </summary>
        public BaseViewModel CurrentChildViewModel
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildViewModel));
            }
        }

        /// <summary>
        /// Polecenie do wyświetlenia widoku strony głównej.
        /// </summary>
        public ICommand ShowHomeViewCommand { get; }

        /// <summary>
        /// Polecenie do wyświetlenia widoku ulubionych.
        /// </summary>
        public ICommand ShowFavouritesViewCommand { get; }

        /// <summary>
        /// Polecenie do wyświetlenia widoku rozrywki.
        /// </summary>
        public ICommand ShowEntertainmentViewCommand { get; }

        /// <summary>
        /// Polecenie do wyświetlenia widoku zdrowia.
        /// </summary>
        public ICommand ShowHealthViewCommand { get; }

        /// <summary>
        /// Polecenie do wyświetlenia widoku nauki.
        /// </summary>
        public ICommand ShowScienceViewCommand { get; }

        /// <summary>
        /// Konstruktor ViewModelu głównego widoku.
        /// </summary>
        public MainViewModel()
        {
            ShowHomeViewCommand = new RelayCommand(ExecuteShowHomeViewCommand);
            ShowFavouritesViewCommand = new RelayCommand(ExecuteShowFavouritesViewCommand);
            ShowEntertainmentViewCommand = new RelayCommand(ExecuteShowEntertainmentViewCommand);
            ShowHealthViewCommand = new RelayCommand(ExecuteShowHealthViewCommand);
            ShowScienceViewCommand = new RelayCommand(ExecuteShowScienceViewCommand);
            ExecuteShowHomeViewCommand(null);
        }

        /// <summary>
        /// Metoda wykonująca polecenie wyświetlenia widoku nauki.
        /// </summary>
        private void ExecuteShowScienceViewCommand(object obj)
        {
            CurrentChildViewModel = new ScienceViewModel();
        }

        /// <summary>
        /// Metoda wykonująca polecenie wyświetlenia widoku zdrowia.
        /// </summary>
        private void ExecuteShowHealthViewCommand(object obj)
        {
            CurrentChildViewModel = new HealthViewModel();
        }

        /// <summary>
        /// Metoda wykonująca polecenie wyświetlenia widoku ulubionych.
        /// </summary>
        private void ExecuteShowFavouritesViewCommand(object obj)
        {
            CurrentChildViewModel = new FavouritesViewModel();
        }

        /// <summary>
        /// Metoda wykonująca polecenie wyświetlenia widoku strony głównej.
        /// </summary>
        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildViewModel = new HomeViewModel();
        }

        /// <summary>
        /// Metoda wykonująca polecenie wyświetlenia widoku rozrywki.
        /// </summary>
        private void ExecuteShowEntertainmentViewCommand(object obj)
        {
            CurrentChildViewModel = new EntertainmentViewModel();
        }
    }
}
