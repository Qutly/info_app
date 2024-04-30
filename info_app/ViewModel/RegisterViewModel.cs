using info_app.Models;
using info_app.Repository;
using info_app.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace info_app.ViewModel
{
    /// <summary>
    /// Klasa ViewModelu rejestracji.
    /// </summary>
    public class RegisterViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        private string _email;
        private bool _isvisible;
        private string _errormsg;

        private IUserInterface userInterface;

        private UserRegister _userRegister;

        /// <summary>
        /// Konstruktor ViewModelu rejestracji.
        /// </summary>
        /// <param name="userRegister">Referencja do widoku rejestracji.</param>
        public RegisterViewModel(UserRegister userRegister)
        {
            _userRegister = userRegister;
            userInterface = new UserRepository();
            Register = new RelayCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
        }

        /// <summary>
        /// Domyślny konstruktor ViewModelu rejestracji.
        /// </summary>
        public RegisterViewModel()
        {
            userInterface = new UserRepository();
            Register = new RelayCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
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
        /// Adres email użytkownika.
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
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
        /// Sprawdza poprawność adresu email.
        /// </summary>
        /// <param name="email">Adres email do sprawdzenia.</param>
        /// <returns>Prawda, jeśli adres email jest poprawny; w przeciwnym razie fałsz.</returns>
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            bool valid = Regex.IsMatch(email, pattern);

            return valid;
        }

        /// <summary>
        /// Polecenie rejestracji.
        /// </summary>
        public ICommand Register { get; }

        /// <summary>
        /// Metoda sprawdzająca, czy można wykonać polecenie rejestracji.
        /// </summary>
        private bool CanExecuteRegisterCommand(object obj)
        {
            using (NewsAppDBEntities db = new NewsAppDBEntities())
            {
                bool valid;
                if (string.IsNullOrEmpty(Username) || Username.Length < 3 || Username == null || Password == null || Password.Length < 3 || !IsValidEmail(Email))
                {
                    valid = false;
                }
                else
                    valid = true;
                return valid;
            }
        }

        /// <summary>
        /// Metoda wywoływana po naciśnięciu przycisku rejestracji.
        /// </summary>
        private void ExecuteRegisterCommand(object obj)
        {
            var isValid = userInterface.RegisterUser(new System.Net.NetworkCredential(Username, Password), Email);
            if (isValid)
            {
                using (NewsAppDBEntities db = new NewsAppDBEntities())
                {
                    User user = new User()
                    {
                        username = Username,
                        password = Password,
                        email = Email,
                    };
                    try
                    {
                        db.User.Add(user);
                        db.SaveChanges();
                        _userRegister.Close();
                    }
                    catch
                    {
                        Errormsg = "Błąd dodania do bazy danych";
                    }
                }
            }
            else
            {
                Errormsg = "Dane istnieją już w bazie danych";
            }
        }
    }
}
