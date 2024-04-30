//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace info_app
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Klasa reprezentuj�ca artyku�.
    /// </summary>
    public partial class Article
    {
        /// <summary>
        /// Konstruktor klasy Article.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Article()
        {
            this.FavouriteAricles = new HashSet<FavouriteAricles>();
        }

        /// <summary>
        /// Identyfikator artyku�u.
        /// </summary>
        public int ArticleId { get; set; }

        /// <summary>
        /// Temat artyku�u.
        /// </summary>
        public string topic { get; set; }

        /// <summary>
        /// Kategoria artyku�u.
        /// </summary>
        public string category { get; set; }

        /// <summary>
        /// Opis artyku�u.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// URL artyku�u.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// Autor artyku�u.
        /// </summary>
        public string author { get; set; }

        /// <summary>
        /// Kolekcja ulubionych artyku��w.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FavouriteAricles> FavouriteAricles { get; set; }
    }
}
