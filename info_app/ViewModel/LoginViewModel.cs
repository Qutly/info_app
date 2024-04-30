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
    /// <summary>
    /// Klasa ViewModelu logowania.
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private int _UserId;
        private string _password;
        private bool _isvisible = true;
        private string _errormsg;

        private IUserInterface userInterface;

        /// <summary>
        /// ID użytkownika.
        /// </summary>
        public int UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }

        /// <summary>
        /// Nazwa użytkownika.
        /// </summary>
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        /// <summary>
        /// Hasło użytkownika.
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        /// <summary>
        /// Flaga określająca widoczność.
        /// </summary>
        public bool Isvisible
        {
            get
            {
                return _isvisible;
            }
            set
            {
                _isvisible = value;
                OnPropertyChanged(nameof(Isvisible));
            }
        }

        /// <summary>
        /// Komunikat o błędzie.
        /// </summary>
        public string Errormsg
        {
            get
            {
                return _errormsg;
            }
            set
            {
                _errormsg = value;
                OnPropertyChanged(nameof(Errormsg));
            }
        }

        /// <summary>
        /// Polecenie logowania.
        /// </summary>
        public ICommand Login { get; }

        /// <summary>
        /// Polecenie rejestracji.
        /// </summary>
        public ICommand Register { get; }

        UserRegister _viewRegister;

        /// <summary>
        /// Konstruktor ViewModelu logowania.
        /// </summary>
        public LoginViewModel()
        {
            userInterface = new UserRepository();
            Login = new RelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            Register = new RelayCommand(ExecuteRegisterCommand);
        }

        /// <summary>
        /// Metoda wywoływana po naciśnięciu przycisku rejestracji.
        /// </summary>
        private void ExecuteRegisterCommand(object obj)
        {
            _viewRegister = new UserRegister();
            RegisterViewModel registerViewModel = new RegisterViewModel(_viewRegister);
            _viewRegister.DataContext = registerViewModel;
            _viewRegister.Show();
        }

        /// <summary>
        /// Metoda sprawdzająca, czy można wykonać polecenie logowania.
        /// </summary>
        private bool CanExecuteLoginCommand(object obj)
        {
            bool valid;
            if (string.IsNullOrEmpty(Username) || Username.Length < 3 || Username == null || Password == null)
                valid = false;
            else
                valid = true;
            return valid;
        }

        /// <summary>
        /// Metoda wywoływana po naciśnięciu przycisku logowania.
        /// </summary>
        private void ExecuteLoginCommand(object obj)
        {
            var userId = userInterface.AuthenticateUser(new System.Net.NetworkCredential(Username, Password));
            if (userId != -1)
            {
                Isvisible = false;
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                UserId = userId;
            }
            else
            {
                Errormsg = "Niepoprawne dane";
            }
        }
    }
}
