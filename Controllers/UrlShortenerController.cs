using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener_UklonTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UrlShortener_UklonTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private static List<Url> Urls = new List<Url>
        {
            new Url("https://en.wikipedia.org/wiki/Worms,_Germany", ShortUrlGenerator.GetShortUrl()),
            new Url("https://en.wikipedia.org/wiki/Battle_of_G%C3%B6llheim", ShortUrlGenerator.GetShortUrl()),
            new Url("https://en.wikipedia.org/wiki/Jacob_Zuma", ShortUrlGenerator.GetShortUrl())
        };

        [HttpGet]
        public string Get([FromBody] string url)
        {
            if (Urls.Any(item => item.FullUrl == url))
            {
                // call put and get short url and stats
                //Urls.Find(item => item.FullUrl == url).ClickDate.Add(DateTime.Now);
                //Urls.Find(item => item.FullUrl == url).ClickCount++;
                //MatchUrl.ClickDate.Add(DateTime.Now);
                //MatchUrl.ClickCount++;
                Put(url);
                Url MatchUrl = Urls.Find(item => item.FullUrl == url);
                return MatchUrl.ShortUrl;
            }
            else
            {
                //call post adn call get by url
                Post(url);
                return "new link added";
            }

        }
        // GET: api/<UrlShortenerController>
        [HttpGet("{all}")]
        public IEnumerable<Url> Get()
        {

            return Urls.ToArray();
        }
        /*// GET api/<UrlShortenerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<UrlShortenerController>
        [HttpPost]
        public ActionResult Post([FromBody] string url)
        {
            if (Urls.Any(item => item.FullUrl == url))
            {
                // call put to add +1 click and click datetime
                Put(url);
                return this.Ok();
            }
            else
            {
                string NewShortUrl = "";
                do
                {
                    NewShortUrl = ShortUrlGenerator.GetShortUrl();
                } while (Urls.Any(item => item.ShortUrl == NewShortUrl));
                Urls.Add(new Url(url, NewShortUrl));
                return this.Ok();
            }
        }

        // PUT api/<UrlShortenerController>/5
        [HttpPut("{url}")]
        public ActionResult Put(string url)
        {
            if (Urls.Any(item => item.FullUrl == url))
            {
                Urls.Find(item => item.FullUrl == url).ClickDate.Add(DateTime.Now);
                Urls.Find(item => item.FullUrl == url).ClickCount++;
                return this.Ok();
            }
            else return this.Problem();
        }

        // DELETE api/<UrlShortenerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
