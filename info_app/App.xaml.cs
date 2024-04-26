using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using info_app.ViewModel;
using info_app.Views;

namespace info_app
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var loginView = new UserLogin();
            loginView.Show();

            loginView.IsVisibleChanged += async (s, ev) =>
            {
                if(loginView.IsVisible == false && loginView.IsLoaded)
                {
                    //var mainViewModel = new MainViewModel();
                    //await mainViewModel.LoadArticlesAsync();

                    var mainView = new MainWindow();
                    //mainView.DataContext = mainViewModel;
                    mainView.Show();
                    loginView.Close();
                }
            };
        }
    }
}
