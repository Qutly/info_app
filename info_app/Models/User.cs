using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info_app.Models
{
    /// <summary>
    /// Klasa reprezentująca użytkownika aplikacji.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Identyfikator użytkownika.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Nazwa użytkownika.
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// Hasło użytkownika.
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Adres e-mail użytkownika.
        /// </summary>
        public string email { get; set; }
    }
}
