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
        /// Logika interakcji dla klasy ScienceView.xaml
        /// </summary>
        public partial class ScienceView : UserControl
        {
            private readonly ScienceViewModel _viewModel;

            /// <summary>
            /// Konstruktor klasy ScienceView.
            /// </summary>
            public ScienceView()
            {
                InitializeComponent();
                _viewModel = new ScienceViewModel();
                DataContext = _viewModel;
            }

            /// <summary>
            /// Metoda wywoływana po załadowaniu widoku.
            /// </summary>
            private async void ScienceView_Loaded(object sender, RoutedEventArgs e)
            {
                await _viewModel.LoadDataFromApiAsync();
            }

            /// <summary>
            /// Obsługa zdarzenia kliknięcia przycisku "AddToFavourites".
            /// </summary>
            private void AddToFavourites_Click(object sender, RoutedEventArgs e)
            {
                var text = (sender as Button).Tag as string;
                // Tutaj możesz dodać logikę obsługi zdarzenia, np. dodawanie do ulubionych.
            }

            /// <summary>
            /// Obsługa zdarzenia kliknięcia przycisku.
            /// </summary>
            private void Button1_Click(object sender, RoutedEventArgs e)
            {
                Button button = (Button)sender;
                int index = int.Parse((string)button.Tag); // Zakładając, że Tag jest ustawiony z indeksem.
                _viewModel.WykonajAkcje(index);
            }
        }
}
