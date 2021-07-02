using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener_UklonTest.Models
{
    public class Url
    {
        public string FullUrl { get; set; }
        public string ShortUrl { get; set; }
        public int ClickCount { get; set; }
        public List<DateTime> ClickDate; 

        public Url (string Full)
        {
            ClickDate = new List<DateTime> { };
            FullUrl = Full;
            ShortUrl = ShortUrlGenerator.GetShortUrl();
            ClickCount = 1;
            ClickDate.Add(DateTime.Now);
        }
        public Url(string Full, string Shrt)
        {
            ClickDate = new List<DateTime> { };
            FullUrl = Full;
            ShortUrl = Shrt;
            ClickCount = 1;
            ClickDate.Add(DateTime.Now);
        }
    }
}
