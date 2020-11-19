using GuardianNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GuardianNews.GuardianApi
{
    public class ArticleProcessor
    {
        private static string _apiKey = "93a97028-e3dd-46ee-acb7-a5f1ac1dbab7";
        public static async Task<List<ArticleModel>> LoadArticles()
        {
            string url = $"search?api-key={ _apiKey }";

            using (HttpResponseMessage response = await ApiProcessor.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ArticleResponseModel results = await response.Content.ReadAsAsync<ArticleResponseModel>();
                    return results.Response.Results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
