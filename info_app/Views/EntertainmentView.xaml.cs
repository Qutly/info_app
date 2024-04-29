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
        public EntertainmentView()
        {
            InitializeComponent();
            _viewModel = new EntertainmentViewModel();
            DataContext = _viewModel;
        }
        private async void EntertainmentView_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadDataFromApiAsync();
        }


        private void AddToFavourites_Click(object sender, RoutedEventArgs e)
        {
            var text = (sender as Button).Tag as string;

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = int.Parse((string)button.Tag); // Assuming Tag is set with the index
            _viewModel.WykonajAkcje(index);
        }
    }
}
