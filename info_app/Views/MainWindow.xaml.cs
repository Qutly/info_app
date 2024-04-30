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
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Konstruktor klasy MainWindow.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metoda obsługująca przeciąganie okna za pasek tytułowy.
        /// </summary>
        private void ControlBarLeftButton(object sender, RoutedEventArgs e)
        {
            DragMove();
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
        /// Obsługuje zdarzenie zaznaczenia przycisku typu RadioButton.
        /// </summary>
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Tu można umieścić logikę związana z obsługą zdarzenia zaznaczenia przycisku RadioButton
        }
    }
}
