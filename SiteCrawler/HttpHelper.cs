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
        public string HOST = string.Empty;

        public HttpHelper(string baseUrl)
        {
            bool uri = Uri.TryCreate(baseUrl, UriKind.Absolute, out Uri? parsedUri);
            if (uri && parsedUri != null)
            {
                HOST = parsedUri.Host;
            }
        }

        public string GetSource(string baseUrl)
        {
            string result = string.Empty;

            if (baseUrl == null || baseUrl.Equals(string.Empty))
                return result;
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

        public string GetHost(string address)
        {
            var result = string.Empty;

            bool uri = Uri.TryCreate(address, UriKind.Absolute, out Uri? parsedUri);
            if (uri && parsedUri != null)
            {
                result = parsedUri.Host;
            }
            return result;
        }

        public bool HasCommonHost(string newHost)
        {
            return newHost.Equals(this.HOST);
        }

        public bool IsUrlValid(string baseUrl)
        {
            return Uri.IsWellFormedUriString(baseUrl, UriKind.Absolute);
        }
    }
}
