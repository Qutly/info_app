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
    public class RegisterViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        private string _email;
        private bool _isvisible;
        private string _errormsg;

        private IUserInterface userInterface;


        private UserRegister _userRegister;

        public RegisterViewModel(UserRegister userRegister)
        {
            _userRegister = userRegister;
            userInterface = new UserRepository();
            Register = new RelayCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
        }
        public RegisterViewModel()
        {
            userInterface = new UserRepository();
            Register = new RelayCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
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

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email)); //gdy wartość jest nadawana musimy powiadomić o zmianie property
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


        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            bool valid = Regex.IsMatch(email, pattern);

            return valid;
        }
        public ICommand Register { get; }

        private bool CanExecuteRegisterCommand(object obj)
        {
            using (NewsAppDBEntities db = new NewsAppDBEntities())
            {
                bool valid;
                if (string.IsNullOrEmpty(Username) || Username.Length < 3 || Username == null || Password == null || Password.Length < 3 ||!IsValidEmail(Email))
                {
                    valid = false;
                }
                else
                    valid = true;
                return valid;
            }
        }
                

        private void ExecuteRegisterCommand(object obj)
        {
            var isValid = userInterface.RegisterUser(new System.Net.NetworkCredential(Username,Password), Email);
            if (isValid)
            {
                using(NewsAppDBEntities db = new NewsAppDBEntities())
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
