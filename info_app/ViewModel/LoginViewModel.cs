using info_app.Models;
using info_app.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using info_app.Repository;
using System.Threading;
using System.Security.Principal;

namespace info_app.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private int _UserId;
        private string _password;
        private bool _isvisible = true;
        private string _errormsg;

        private IUserInterface userInterface;

        public int UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
                OnPropertyChanged(nameof(UserId)); //gdy wartość jest nadawana musimy powiadomić o zmianie property
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username)); //gdy wartość jest nadawana musimy powiadomić o zmianie property
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password)); //gdy wartość jest nadawana musimy powiadomić o zmianie property
            }
        }


        public bool Isvisible
        {
            get
            {
                return _isvisible;
            }
            set
            {
                _isvisible = value;
                OnPropertyChanged(nameof(Isvisible)); //gdy wartość jest nadawana musimy powiadomić o zmianie property
            }
        }
        public string Errormsg
        {
            get
            {
                return _errormsg;
            }
            set
            {
                _errormsg = value;
                OnPropertyChanged(nameof(Errormsg)); //gdy wartość jest nadawana musimy powiadomić o zmianie property
            }
        }


        public ICommand Login { get; }
        public ICommand Register { get; }

        UserRegister _viewRegister;

        public LoginViewModel()
        {
            userInterface = new UserRepository();
            Login = new RelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            Register = new RelayCommand(ExecuteRegisterCommand);
        }

        private void ExecuteRegisterCommand(object obj)
        {
            _viewRegister = new UserRegister();
            RegisterViewModel registerViewModel = new RegisterViewModel(_viewRegister);
            _viewRegister.DataContext = registerViewModel; // Ustawienie kontekstu danych dla okna rejestracji
            _viewRegister.Show();
        }


        private bool CanExecuteLoginCommand(object obj)
        {
            
            bool valid;
            if (string.IsNullOrEmpty(Username) || Username.Length < 3 || Username == null || Password == null)
                valid = false;
            else
                valid = true;
            return valid;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var userId = userInterface.AuthenticateUser(new System.Net.NetworkCredential(Username, Password));
            if(userId != -1)
            {
                Isvisible = false;
                UserId = userId;
            }
            else
            {
                Errormsg = "Niepoprawne dane";
            }
        }
    }
}
