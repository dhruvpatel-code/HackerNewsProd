using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsProd.Services
{
    public class MockHackerArticlesService
    {
        // Using Moq to isolate class under test from its dependencies to ensure proper methods on dependent objects are being called.
        public static IMemoryCache GetArticleFromMemoryCache(object exValue)
        {
            var mockArticleCache = new Mock<IMemoryCache>();
            mockArticleCache.Setup(x => x.TryGetValue(It.IsAny<object>(), out exValue)).Returns(true);

            return mockArticleCache.Object;
        }
    }
}
