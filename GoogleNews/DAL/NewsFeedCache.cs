using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace GoogleNewsApp.DAL
{
    public class NewsFeedCache
    {
        private readonly IMemoryCache _cache;
        private readonly HttpClient _httpClient;

        public NewsFeedCache(IMemoryCache cache, HttpClient httpClient)
        {
            _cache = cache;
            _httpClient = httpClient;
        }

        //The data retrieval function
        public async Task<string> GetNewsFeedAsync()
        {
            //Checking whether the data appears in the cache
            if (!_cache.TryGetValue("NewsFeed", out string feed))
            {
                feed = await _httpClient.GetStringAsync("http://news.google.com/news?pz=1&cf=all&ned=en_il&hl=en&output=rss");
                _cache.Set("NewsFeed", feed, TimeSpan.FromMinutes(30));
            }
            //data return
            return feed;
        }
    }
}
