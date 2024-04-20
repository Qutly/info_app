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

namespace info_app
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public static async Task LoadArticle(string category_name)
        {
            var article = await ArticleProcessor.GetArticle(category_name);


            Console.WriteLine($"Title: {article.Title}");
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadArticle("entertainment");
        }
    }
}
