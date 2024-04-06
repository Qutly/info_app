using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info_app.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DateOfPublish { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public ICollection<FavouriteArticle> FavouriteArticles { get; set; }
    }
}
