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
    public class FavouritesViewModel: BaseViewModel
    {
        private ObservableCollection<Article> _favouriteArticles;
        private IUserInterface _UserInterface;
        private UserAccount _userAccount;
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

        public FavouritesViewModel()
        {
            _UserInterface = new UserRepository();
            LoadData();
            LoadFavouriteArticles();
        }

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
