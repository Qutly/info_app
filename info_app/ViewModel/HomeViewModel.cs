using info_app.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;


namespace info_app.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        private ObservableCollection<Article> _TopArticles;
        public List<Article> Articles { get; set; }
        //public DelegateCommand<int?> AddToFavouritesCommand { get; }
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
        public HomeViewModel()
        {
            //AddToFavouritesCommand = new DelegateCommand<int?>(AddToFavourites);
            TopArticles = new ObservableCollection<Article>();
        }

        public void WykonajAkcje(int index)
        {
            Article selectedArticle = TopArticles[index];

            try
            {
                using (NewsAppDBEntities db = new NewsAppDBEntities())
                {
                    Console.WriteLine(selectedArticle.ArticleId);
                    db.Article.Add(selectedArticle);
                    db.SaveChanges();
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
                    var endpoint = new Uri("https://newsapi.org/v2/top-headlines?country=us&category=entertainment&country=pl&apiKey=154c124767314fe8b90474373b282a44");
                    var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

                    request.Headers.Add("User-Agent", "info_app/1.0");

                    var response = await client.SendAsync(request);

                    var result = await response.Content.ReadAsStringAsync();

                    var articlesResponse = JsonConvert.DeserializeObject<NewsApiResponse>(result);
                    Articles = new List<Article>();
                    for (int i = 0; i < 6 && i < articlesResponse.Articles.Count; i++)
                    {
                        var articleResponse = articlesResponse.Articles[i];
                        Articles.Add(new Article
                        {
                            topic = articleResponse.Title,
                            url = articleResponse.Url,
                            category = "Entertainment",
                            author = articleResponse.Author,
                            description = ""
                        });
                    }
                    TopArticles = new ObservableCollection<Article>(Articles);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());  
                }

                finally
                {
                    client.Dispose();
                }
            }
        }
    }
}
