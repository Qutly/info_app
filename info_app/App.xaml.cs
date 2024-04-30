using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using info_app.Models;
using info_app.ViewModel;
using info_app.Views;

namespace info_app
{
    /// <summary>
    /// Klasa reprezentująca aplikację.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Metoda wywoływana podczas uruchamiania aplikacji.
        /// </summary>
        /// <param name="sender">Obiekt źródłowy zdarzenia.</param>
        /// <param name="e">Argumenty zdarzenia Startup.</param>
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var loginView = new UserLogin();
            loginView.Show();

            loginView.IsVisibleChanged += async (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {

                    // Otwarcie widoku głównego po zalogowaniu i zamknięciu widoku logowania.
                    var mainView = new MainWindow();
                    mainView.Show();
                    loginView.Close();
                }
            };
        }
    }

}
