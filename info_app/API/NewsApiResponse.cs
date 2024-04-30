using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info_app.API
{
    /// <summary>
    /// Reprezentuje odpowiedź z API News.
    /// </summary>
    public class NewsApiResponse
    {
        /// <summary>
        /// Status odpowiedzi.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Całkowita liczba wyników.
        /// </summary>
        public int TotalResults { get; set; }

        /// <summary>
        /// Lista artykułów.
        /// </summary>
        public List<ArticleResponse> Articles { get; set; }
    }
}
