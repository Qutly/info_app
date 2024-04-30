using info_app.Models;
using System.Linq;
using System.Net;

namespace info_app.Repository
{
    /// <summary>
    /// Repozytorium użytkowników, implementujące interfejs IUserInterface.
    /// </summary>
    public class UserRepository : IUserInterface
    {
        /// <summary>
        /// Metoda uwierzytelniająca użytkownika na podstawie danych uwierzytelniających.
        /// </summary>
        /// <param name="credential">Dane uwierzytelniające.</param>
        /// <returns>Identyfikator użytkownika lub -1, jeśli uwierzytelnienie nie powiedzie się.</returns>
        public int AuthenticateUser(NetworkCredential credential)
        {
            int id = -1;
            using (NewsAppDBEntities db = new NewsAppDBEntities())
            {
                var record = db.User.FirstOrDefault(x => x.username == credential.UserName);
                if (record != null && record.password == credential.Password)
                {
                    id = record.UserId;
                }
            }
            return id;
        }

        /// <summary>
        /// Metoda rejestracji użytkownika.
        /// </summary>
        /// <param name="credential">Dane uwierzytelniające.</param>
        /// <param name="email">Adres e-mail użytkownika.</param>
        /// <returns>Prawda, jeśli rejestracja zakończyła się sukcesem, w przeciwnym razie fałsz.</returns>
        public bool RegisterUser(NetworkCredential credential, string email)
        {
            using (NewsAppDBEntities db = new NewsAppDBEntities())
            {
                bool isEmailUnique = !db.User.Any(u => u.email == email);
                bool isUsernameUnique = !db.User.Any(u => u.username == credential.UserName);
                return isEmailUnique && isUsernameUnique;
            }
        }

        /// <summary>
        /// Metoda pobierająca użytkownika na podstawie nazwy użytkownika.
        /// </summary>
        /// <param name="username">Nazwa użytkownika.</param>
        /// <returns>Obiekt użytkownika lub null, jeśli użytkownik nie istnieje.</returns>
        public Models.User GetByUsername(string username)
        {
            return new Models.User()
            {
                username = username,
                email = "",
                UserId = 0,
                password = ""
            };
        }
    }
}
