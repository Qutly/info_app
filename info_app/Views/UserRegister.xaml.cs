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
    /// Logika interakcji dla klasy UserRegister.xaml
    /// </summary>
    public partial class UserRegister : Window
    {
        /// <summary>
        /// Konstruktor klasy UserRegister.
        /// </summary>
        public UserRegister()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Obsługuje zdarzenie kliknięcia przycisku minimalizacji.
        /// </summary>
        private void buttonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Obsługuje zdarzenie kliknięcia przycisku zamknięcia okna.
        /// </summary>
        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Metoda zamykająca okno.
        /// </summary>
        public void CloseWindow()
        {
            this.Close();
        }
    }
}
