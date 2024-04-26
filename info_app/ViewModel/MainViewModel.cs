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

namespace info_app.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        private BaseViewModel _currentChildView;
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
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowFavouritesViewCommand { get; }

        public MainViewModel()
        {
            ShowHomeViewCommand = new RelayCommand(ExecuteShowHomeViewCommand);
            ShowFavouritesViewCommand = new RelayCommand(ExecuteShowFavouritesViewCommand);
            ExecuteShowHomeViewCommand(null);
        }

        private void ExecuteShowFavouritesViewCommand(object obj)
        {
            CurrentChildViewModel = new FavouritesViewModel();
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildViewModel = new HomeViewModel();

        }



    }
}
