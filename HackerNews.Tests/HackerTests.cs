using HackerNewsProd.Controllers;
using HackerNewsProd.Services;
using System;
using FakeItEasy;
using Xunit;
using System.Threading.Tasks;
using HackerNewsProd.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NuGet.Frameworks;

namespace HackerNews.Tests
{
    public class HackerTests
    {
        // xUnit test to make sure we are getting articles returned from the Api and cached memory.
        [Fact]
        public async Task GetNewArticles_Returns_New_Articles_Greater_Than20()
        {
            object exResult = null;

            var mockArticleCache = MockHackerArticlesService.GetArticleFromMemoryCache(exResult);

            var hackerServiceCache = new HackerArticles(mockArticleCache);

            List<HackerModel> newNewsArticles = await hackerServiceCache.GetNewNewsArticles();

            Assert.NotEqual(20, newNewsArticles.Count);
        }
    }
}
