using System.Net;

namespace info_app.Models
{
    /// <summary>
    /// Interfejs definiujący operacje związane z użytkownikami.
    /// </summary>
    public interface IUserInterface
    {
        /// <summary>
        /// Metoda uwierzytelniająca użytkownika na podstawie danych uwierzytelniających.
        /// </summary>
        /// <param name="credential">Dane uwierzytelniające.</param>
        /// <returns>Identyfikator użytkownika lub -1, jeśli uwierzytelnienie nie powiedzie się.</returns>
        int AuthenticateUser(NetworkCredential credential);

        /// <summary>
        /// Metoda rejestracji użytkownika.
        /// </summary>
        /// <param name="credential">Dane uwierzytelniające.</param>
        /// <param name="email">Adres e-mail użytkownika.</param>
        /// <returns>Prawda, jeśli rejestracja zakończyła się sukcesem, w przeciwnym razie fałsz.</returns>
        bool RegisterUser(NetworkCredential credential, string email);

        /// <summary>
        /// Metoda pobierająca użytkownika na podstawie nazwy użytkownika.
        /// </summary>
        /// <param name="username">Nazwa użytkownika.</param>
        /// <returns>Obiekt użytkownika lub null, jeśli użytkownik nie istnieje.</returns>
        User GetByUsername(string username);
    }
}
