using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener_UklonTest
{
    public static class ShortUrlGenerator
    {
        public static string GetShortUrl()
        {
            Random rand = new Random();
            string ShortUrl = "";
            char[] letters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz".ToCharArray();
            for (int j = 1; j <= 20; j++)
            {
                int letter_num = rand.Next(0, letters.Length - 1);
                ShortUrl +=  letters[letter_num];
            }
            return ShortUrl;
        }
    }
}
