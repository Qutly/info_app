using info_app.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace info_app.Views
{
    /// <summary>
    /// Logika interakcji dla klasy EntertainmentView.xaml
    /// </summary>
    public partial class EntertainmentView : UserControl
    {
        private readonly EntertainmentViewModel _viewModel;

        /// <summary>
        /// Konstruktor klasy EntertainmentView.
        /// </summary>
        public EntertainmentView()
        {
            InitializeComponent();
            _viewModel = new EntertainmentViewModel();
            DataContext = _viewModel;
        }

        /// <summary>
        /// Obsługuje zdarzenie Loaded dla widoku EntertainmentView.
        /// </summary>
        private async void EntertainmentView_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadDataFromApiAsync();
        }

        /// <summary>
        /// Obsługuje kliknięcie przycisku "AddToFavourites".
        /// </summary>
        private void AddToFavourites_Click(object sender, RoutedEventArgs e)
        {
            var text = (sender as Button).Tag as string;
        }

        /// <summary>
        /// Obsługuje kliknięcie przycisku Button1.
        /// </summary>
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = int.Parse((string)button.Tag); // Zakładając, że Tag jest ustawiony z indeksem
            _viewModel.WykonajAkcje(index);
        }
    }
}

