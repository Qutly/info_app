using info_app.API;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace info_app
{
    public class ArticleProcessor
    {
        public static async Task<Article> GetArticle(string category_name)
        {
            string url = $"https://newsapi.org/v2/top-headlines?country=us&category={category_name}&country=pl&apiKey=154c124767314fe8b90474373b282a44";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if(response.IsSuccessStatusCode)
                {
                    Article article = await response.Content.ReadAsAsync<Article>();
                    return article;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
