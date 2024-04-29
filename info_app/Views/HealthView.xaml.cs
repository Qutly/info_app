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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace info_app.Views
{
    /// <summary>
    /// Logika interakcji dla klasy HealthView.xaml
    /// </summary>
    public partial class HealthView : UserControl
    {
        private readonly HealthViewModel _viewModel;
        public HealthView()
        {
            InitializeComponent();
            _viewModel = new HealthViewModel();
            DataContext = _viewModel;
        }
        private async void HealthView_Loaded(object sender, RoutedEventArgs e)
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

