using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info_app.Models
{
    public class FavouriteArticle
    {
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public User User { get; set; }
        public Article Article { get; set; }
    }
}
