//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;

namespace info_app
{
    /// <summary>
    /// Reprezentuje użytkownika aplikacji.
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// Konstruktor domyślny inicjalizujący kolekcję ulubionych artykułów użytkownika.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.FavouriteAricles = new HashSet<FavouriteAricles>();
        }

        /// <summary>
        /// Identyfikator użytkownika.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Nazwa użytkownika.
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// Adres e-mail użytkownika.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Hasło użytkownika.
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Kolekcja ulubionych artykułów użytkownika.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FavouriteAricles> FavouriteAricles { get; set; }
    }
}

