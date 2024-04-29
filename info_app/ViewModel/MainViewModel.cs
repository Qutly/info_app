﻿using info_app.ViewModel;
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
        private int _UserId;
        
        public int UserId
        {
            get { return _UserId; }
            set
            {
                _UserId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }
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
        public ICommand ShowEntertainmentViewCommand { get; }
        public ICommand ShowHealthViewCommand { get; }
        public ICommand ShowScienceViewCommand { get; }

        public MainViewModel()
        {
            ShowHomeViewCommand = new RelayCommand(ExecuteShowHomeViewCommand);
            ShowFavouritesViewCommand = new RelayCommand(ExecuteShowFavouritesViewCommand);
            ShowEntertainmentViewCommand = new RelayCommand(ExecuteShowEntertainmentViewCommand);
            ShowHealthViewCommand = new RelayCommand(ExecuteShowHealthViewCommand);
            ShowScienceViewCommand = new RelayCommand(ExecuteShowScienceViewCommand);
            ExecuteShowHomeViewCommand(null);
        }

        private void ExecuteShowScienceViewCommand(object obj)
        {
            CurrentChildViewModel = new ScienceViewModel();
        }

        private void ExecuteShowHealthViewCommand(object obj)
        {
            CurrentChildViewModel = new HealthViewModel();
        }

        private void ExecuteShowFavouritesViewCommand(object obj)
        {
            CurrentChildViewModel = new FavouritesViewModel();
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildViewModel = new HomeViewModel();

        }

        private void ExecuteShowEntertainmentViewCommand(object obj)
        {
            CurrentChildViewModel = new EntertainmentViewModel();
        }

    


    }
}
