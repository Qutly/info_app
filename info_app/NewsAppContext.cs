using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using info_app.Models;

namespace info_app
{
    public class NewsApp : DbContext
    {
        public NewsApp()
            : base("name=NewsApp")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<User> Users { get; set; }
        public DbSet<FavouriteArticle> FavoriteArticles { get; set; }
        public DbSet<Article> Articles { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}