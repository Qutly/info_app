using System.Collections.Generic;

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
        public virtual ICollection<FavouriteArticle> FavouriteArticles { get; set; }
        public Article(int id, string url, string title, string description, string dateOfPublish, string author, string category, ICollection<FavouriteArticle> favouriteArticles)
        {
            Id = id;
            Url = "x";
            Title = "tytul";
            Description = "description";
            DateOfPublish = "dateOfPublish";
            Author = "author";
            Category = "category";
            FavouriteArticles = favouriteArticles;
        }
    }
}
