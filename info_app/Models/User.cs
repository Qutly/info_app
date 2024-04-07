using System.Collections.Generic;

namespace info_app.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual ICollection<FavouriteArticle> FavouriteArticles { get; set; }

        public User(int id, string username, string password, ICollection<FavouriteArticle> favourite_articles)
        {
            Id = id;
            Username = username;
            Password = password;

            FavouriteArticles = favourite_articles;
        }
    }
}
