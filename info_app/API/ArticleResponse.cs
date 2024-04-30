using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info_app.API
{
    /// <summary>
    /// Reprezentuje odpowiedź na artykuł z API News.
    /// </summary>
    public class ArticleResponse
    {
        /// <summary>
        /// Tytuł artykułu.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Adres URL artykułu.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Adres URL obrazka artykułu.
        /// </summary>
        public string UrlToImage { get; set; }

        /// <summary>
        /// Autor artykułu.
        /// </summary>
        public string Author { get; set; }
    }
}
