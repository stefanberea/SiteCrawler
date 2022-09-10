using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace SiteCrawler
{
    public class HttpHelper
    {
        public static bool IsValidUrl(string baseUrl)
        {
            bool uri = Uri.TryCreate(baseUrl, UriKind.Absolute, out Uri? parsedUri);
            return uri && parsedUri != null;
        }

        public static string GetHtml(string baseUrl)
        {
            string result = string.Empty;

            if (baseUrl == null || baseUrl.Equals(string.Empty))
                return result;
            if (!IsUrlValid(baseUrl))
                return result;

            try
            {
                using (HttpClient client = new())
                {
                    using HttpResponseMessage response = client.GetAsync(baseUrl).Result;
                    using HttpContent content = response.Content;
                    result = content.ReadAsStringAsync().Result;
                }
            }
            catch (AggregateException e)
            {
                return result;
            }

            return result;
        }

        public static string GetHost(string address)
        {
            var result = string.Empty;

            bool uri = Uri.TryCreate(address, UriKind.Absolute, out Uri? parsedUri);
            if (uri && parsedUri != null)
            {
                result = parsedUri.Host;
            }
            return result;
        }

        public static bool HaveCommonHost(string newHost, string oldHost)
        {
            return newHost.Equals(oldHost);
        }

        public static bool IsUrlValid(string baseUrl)
        {
            return Uri.IsWellFormedUriString(baseUrl, UriKind.Absolute);
        }
    }
}
