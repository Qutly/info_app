﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace info_app.MVVM.View
{
    /// <summary>
    /// Logika interakcji dla klasy UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void buttonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            newsappdatabaseEntities2 db = new newsappdatabaseEntities2();
            var typed_username = usernameTxt.Text;
            var typed_password = passwordTxt.Text;
            Console.WriteLine($"username: {typed_username}");

            var record = db.User.FirstOrDefault(x => x.username == typed_username);
            if (record != null)
            {
                if (record.password ==  typed_password)
                {
                    Console.WriteLine("Login successful.");
                    Close();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Main.Cont
                }
            }

        }
    }
}
