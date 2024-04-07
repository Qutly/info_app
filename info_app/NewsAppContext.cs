using info_app.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace info_app
{
    public class NewsAppContext : DbContext
    {
        public NewsAppContext()
            : base("name=NewsAppContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<User> Users { get; set; }
        public DbSet<FavouriteArticle> FavoriteArticles { get; set; }
        public DbSet<Article> Articles { get; set; }

    }

    public class UniversityDbInitializer : DropCreateDatabaseAlways<NewsAppContext>
    {

        protected override void Seed(NewsAppContext context)
        {
            var article = new Article(100, "https://www.example.com", "Sample Article Title", "Sample description", "2024-04-07", "Sample Author", "Sample Category", null);
            var users = new List<User>
            {
                    new User(1,
                        "Robotics",
                        "123",
                        new Collection<FavouriteArticle> {
                        new FavouriteArticle() {
                            UserId = 1,
                            ArticleId= 100,
                            Article = article
                            }
                        }) ,
                };
            users.ForEach(c => context.Users.Add(c));
            context.SaveChanges();

            List<User> courses_db = context.Users.ToList();
        }
    }
}