using info_app.Core;
using System;

namespace info_app.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand GeneralViewCommand { get; set; }
        public RelayCommand HealthViewCommand { get; set; }
        public RelayCommand ScienceViewCommand { get; set; }
        public RelayCommand TechnologyViewCommand { get; set; }
        public RelayCommand EntertainmentViewCommand { get; set; }


        public HomeViewModel HomeVM { get; set; }

        public GeneralViewModel GeneralVM { get; set; }
        public HealthViewModel HealthVM { get; set; }
        public ScienceViewModel ScienceVM { get; set; }
        public TechnologyViewModel TechnologyVM { get; set; }
        public EntertainmentViewModel EntertainmentVM { get; set; }


        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            GeneralVM = new GeneralViewModel();
            HealthVM = new HealthViewModel();
            ScienceVM = new ScienceViewModel();
            TechnologyVM = new TechnologyViewModel();
            EntertainmentVM = new EntertainmentViewModel();


            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            GeneralViewCommand = new RelayCommand(o =>
            {
                CurrentView = GeneralVM;
            });

            HealthViewCommand = new RelayCommand(o =>
            {
                CurrentView = HealthVM;
            });

            ScienceViewCommand = new RelayCommand(o =>
            {
                CurrentView = ScienceVM;
            });

            TechnologyViewCommand = new RelayCommand(o =>
            {
                CurrentView = TechnologyVM;
            });

            EntertainmentViewCommand = new RelayCommand(o =>
            {
                CurrentView = EntertainmentVM;
            });
        }
    }
}
