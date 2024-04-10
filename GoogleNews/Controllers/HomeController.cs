using GoogleNewsApp.Models;
using GoogleNewsApp.DAL;
using GoogleNewsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace GoogleNewsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewsFeedCache _newsFeedCache;

        public HomeController(NewsFeedCache newsFeedCache)
        {
            _newsFeedCache = newsFeedCache;
        }

        public async Task<IActionResult> Index()
        {
            // Fetch news feed data
            string newsFeed = await _newsFeedCache.GetNewsFeedAsync();
            //Send to function
            var newsTopics = ParseNewsFeed(newsFeed);
            return View(newsTopics);
        }

        //A function to convert the received measure into a NewsTopic type list with the appropriate properties
        private List<NewsTopic> ParseNewsFeed(string newsFeed)
        {
            List<NewsTopic> newsTopics = new List<NewsTopic>();
            var xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml(newsFeed);
            //Go through the loop to convert to a NewsTopic object
            foreach (XmlNode itemNode in xmlDoc.SelectNodes("//item"))
            {
                var newsTopic = new NewsTopic
                {
                    Title = itemNode.SelectSingleNode("title").InnerText,
                    Description = itemNode.SelectSingleNode("description").InnerText,
                    Link = itemNode.SelectSingleNode("link").InnerText
                };
                newsTopics.Add(newsTopic);
            }
            return newsTopics;
        }
    }
}
