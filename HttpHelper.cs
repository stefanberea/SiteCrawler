using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace SiteCrawler
{
    public class HttpHelper
    {
        public static string GetSource(string baseUrl)
        {
            string result = string.Empty;
            if (!IsUrlValid(baseUrl))
                return result;

            using (HttpClient client = new())
            {
                using HttpResponseMessage response = client.GetAsync(baseUrl).Result;
                using HttpContent content = response.Content;
                result = content.ReadAsStringAsync().Result;
            }

            return result;
        }

        private static bool IsUrlValid(string baseUrl)
        {
            return Uri.IsWellFormedUriString(baseUrl, UriKind.Absolute);
        }
    }
}
