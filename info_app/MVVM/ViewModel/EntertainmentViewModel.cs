using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using info_app.API;

namespace info_app.MVVM.ViewModel
{
    class EntertainmentViewModel
    {
        private readonly HttpClient _client;

        public EntertainmentViewModel()
        {
            _client = new HttpClient();
        }

        public List<Article> Articles { get; private set; }

        public async Task FetchDataAsync()
        {
            try
            {
                var endpoint = new Uri("https://newsapi.org/v2/top-headlines?country=us&category=entertainment&country=pl&apiKey=154c124767314fe8b90474373b282a44");
                var request = new HttpRequestMessage(HttpMethod.Get, endpoint);

                request.Headers.Add("User-Agent", "info_app/1.0");

                var response = await _client.SendAsync(request);

                var result = await response.Content.ReadAsStringAsync();

                var articlesResponse = JsonConvert.DeserializeObject<NewsApiResponse>(result);

                Articles = new List<Article>();
                for (int i = 0; i < 6 && i < articlesResponse.Articles.Count; i++)
                {
                    var articleResponse = articlesResponse.Articles[i];
                    Articles.Add(new Article
                    {
                        Title = articleResponse.Title,
                        Url = articleResponse.Url,
                        UrlToImage = articleResponse.UrlToImage
                    });
                }

                foreach (var article in Articles)
                {
                    Console.WriteLine($"Title: {article.Title}");
                    Console.WriteLine($"URL: {article.Url}");
                    Console.WriteLine($"URL to Image: {article.UrlToImage}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędów
            }

            finally
            {
                _client.Dispose();
            } 
        }
    }
}
