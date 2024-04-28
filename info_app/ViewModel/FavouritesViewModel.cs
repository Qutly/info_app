using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info_app.ViewModel
{
    public class FavouritesViewModel: BaseViewModel
    {
        private ObservableCollection<Article> _favouriteArticles;

        public ObservableCollection<Article> FavouriteArticles
        {
            get { return _favouriteArticles; }
            set
            {
                _favouriteArticles = value;
                OnPropertyChanged(nameof(FavouriteArticles));
            }
        }
        private void LoadFavouriteArticles()
        {
            using (NewsAppDBEntities2 db = new NewsAppDBEntities2())
            {
                // Pobierz ArticleId dla użytkownika o UserId = 2 z tabeli FavouriteArticles
                var favouriteArticleIds = db.FavouriteAricles
                                             .Where(f => f.UserId == 2)
                                             .Select(f => f.ArticleId)
                                             .ToList();

                // Pobierz artykuły z tabeli Article, które mają ArticleId z listy favouriteArticleIds
                FavouriteArticles = new ObservableCollection<Article>(db.Article
                                                                         .Where(a => favouriteArticleIds.Contains(a.ArticleId))
                                                                         .ToList());
            }
        }

        public FavouritesViewModel()
        {
            LoadFavouriteArticles();
        }
    }
}
