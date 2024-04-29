using info_app.API;
using info_app.Models;
using info_app.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace info_app.ViewModel
{
    public class HealthViewModel : BaseViewModel
    {
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
        private ObservableCollection<Article> _TopArticles;
        public List<Article> Articles { get; set; }
        public ObservableCollection<Article> TopArticles
        {
            get
            {
                return _TopArticles;
            }
            set
            {
                _TopArticles = value;
                OnPropertyChanged(nameof(TopArticles));
            }
        }
        public HealthViewModel()
        {
            _UserInterface = new UserRepository();
            LoadData();
            TopArticles = new ObservableCollection<Article>();
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
        public void WykonajAkcje(int index)
        {
            Article selectedArticle = TopArticles[index];
            try
            {
                using (NewsAppDBEntities2 db = new NewsAppDBEntities2())
                {
                    if (db.Article.Any(article => article.topic == selectedArticle.topic))
                    {

                    }
                    else
                    {
                        var user = db.User.FirstOrDefault(u => u.username == CurrentUserAccount.Username);
                        if (user != null)
                        {
                            db.Article.Add(selectedArticle);
                            db.SaveChanges();
                            Console.WriteLine(selectedArticle.ArticleId);
                            FavouriteAricles FavObj = new FavouriteAricles()
                            {
                                ArticleId = selectedArticle.ArticleId,
                                UserId = user.UserId,
                            };
                            db.FavouriteAricles.Add(FavObj);
                            db.SaveChanges();
                        }

                    }

                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        internal async Task LoadDataFromApiAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var endpoint = new Uri("https://newsapi.org/v2/top-headlines?country=us&category=health&country=pl&apiKey=154c124767314fe8b90474373b282a44");
                    var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

                    request.Headers.Add("User-Agent", "info_app/1.0");

                    var response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            var articlesResponse = JsonConvert.DeserializeObject<NewsApiResponse>(result);
                            Articles = new List<Article>();
                            for (int i = 0; i < 6 && i < articlesResponse.Articles.Count; i++)
                            {
                                var articleResponse = articlesResponse.Articles[i];
                                if (!string.IsNullOrWhiteSpace(articleResponse.Title) && !string.IsNullOrWhiteSpace(articleResponse.Url) && !string.IsNullOrWhiteSpace(articleResponse.Author))
                                {
                                    Articles.Add(new Article
                                    {
                                        topic = articleResponse.Title,
                                        url = articleResponse.Url,
                                        category = "Health",
                                        author = articleResponse.Author,
                                        description = ""
                                    });
                                }
                            }
                            TopArticles = new ObservableCollection<Article>(Articles);
                        }
                        else
                        {
                            Console.WriteLine("Pusta odpowiedź API.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Fail zapytania API: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error podczas ładowania danych z API: {ex}");
                }
            }
        }
    }
}
