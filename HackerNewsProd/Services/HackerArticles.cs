using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System;
using HackerNewsProd.Models;
using System.Linq;
using HackerNewsProd.Services;

namespace HackerNewsProd.Services
{
    public class HackerArticles : IHackerArticles
    {
        private readonly string baseUrl = "https://hacker-news.firebaseio.com/v0/";
        private readonly IMemoryCache _cacheArticles;
        private static readonly HttpClient _httpClient = new HttpClient();

        public HackerArticles(IMemoryCache articleCache)
        {
            _cacheArticles = articleCache;
        }

        public async Task<List<HackerModel>> GetNewNewsArticles()
        {
            List<HackerModel> newNewsArticlesList = new List<HackerModel>();

            try
            {
                var reponseNewStories = await _httpClient.GetAsync(baseUrl + "newstories.json?print=pretty");

                if (reponseNewStories.StatusCode == HttpStatusCode.OK)
                {
                    var responseContent = reponseNewStories.Content.ReadAsStringAsync().Result;

                    newNewsArticlesList = await ConvertResponseToJSON(newNewsArticlesList, responseContent);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return newNewsArticlesList;

        }

        private async Task<List<HackerModel>> ConvertResponseToJSON(List<HackerModel> newsArticlesList, string responseContent)
        {
            try
            {
                var newsArticlesJSONConverted = JsonConvert.DeserializeObject<List<int>>(responseContent);

                var newsArticles = newsArticlesJSONConverted.Select(GetNewsArticlesByID);

                newsArticlesList = (await Task.WhenAll(newsArticles)).ToList();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return newsArticlesList;
        }

        private async Task<HackerModel> GetNewsArticlesByID(int id)
        {
            return await _cacheArticles.GetOrCreateAsync(id, async cacheArticles =>
            {
                HackerModel newsArticlesByID = new HackerModel();

                if (cacheArticles is null)
                {
                    throw new ArgumentNullException(nameof(cacheArticles));
                }

                try
                {
                    var responseNewsArticlesByID = await _httpClient.GetAsync(string.Format(baseUrl + "item/{0}.json?print=pretty", id));

                    if (responseNewsArticlesByID.StatusCode == HttpStatusCode.OK)
                    {
                        var responseContent = responseNewsArticlesByID.Content.ReadAsStringAsync().Result;

                        newsArticlesByID = JsonConvert.DeserializeObject<HackerModel>(responseContent);
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }

                return newsArticlesByID;
            });


        }
    }
}