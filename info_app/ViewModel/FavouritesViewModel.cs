using info_app.Models;
using info_app.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace info_app.ViewModel
{
    /// <summary>
    /// ViewModel dla widoku ulubionych artykułów.
    /// </summary>
    public class FavouritesViewModel : BaseViewModel
    {
        private ObservableCollection<Article> _favouriteArticles;
        private IUserInterface _UserInterface;
        private UserAccount _userAccount;

        /// <summary>
        /// Aktualne konto użytkownika.
        /// </summary>
        public UserAccount CurrentUserAccount
        {
            get
            {
                return _userAccount;
            }
            set
            {
                _userAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount)); //gdy wartość jest nadawana musimy powiadomić o zmianie property
            }
        }

        /// <summary>
        /// Lista ulubionych artykułów.
        /// </summary>
        public ObservableCollection<Article> FavouriteArticles
        {
            get { return _favouriteArticles; }
            set
            {
                _favouriteArticles = value;
                OnPropertyChanged(nameof(FavouriteArticles));
            }
        }

        /// <summary>
        /// Metoda wczytująca ulubione artykuły użytkownika.
        /// </summary>
        private void LoadFavouriteArticles()
        {
            using (NewsAppDBEntities db = new NewsAppDBEntities())
            {
                var user = db.User.FirstOrDefault(u => u.username == CurrentUserAccount.Username);
                if (user != null)
                {
                    var favouriteArticleIds = db.FavouriteAricles
                                             .Where(f => f.UserId == user.UserId)
                                             .Select(f => f.ArticleId)
                                             .ToList();

                    FavouriteArticles = new ObservableCollection<Article>(db.Article
                                                                             .Where(a => favouriteArticleIds.Contains(a.ArticleId))
                                                                             .ToList());

                }

            }
        }

        /// <summary>
        /// Konstruktor FavouritesViewModel.
        /// </summary>
        public FavouritesViewModel()
        {
            _UserInterface = new UserRepository();
            LoadData();
            LoadFavouriteArticles();
        }

        /// <summary>
        /// Metoda wczytująca dane.
        /// </summary>
        private void LoadData()
        {
            var user = _UserInterface.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user == null) { }
            else
            {
                CurrentUserAccount = new UserAccount()
                {
                    Username = user.username
                };

            }
        }
    }
}
