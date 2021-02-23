using Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common.Utilities.Download
{
    public class Downloader : IDownloader
    {
        private readonly ILogger _logger;

        public Downloader(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<string> GetHtmlFromPageAsync(string pageUrl, object data, Dictionary<string, string> headers)
        {
            try
            {
                string UrlParemeter = "";

                string url = pageUrl + UrlParemeter.Trim(new char[] { '&' });

                HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

                objRequest.ContentType = "text/html; charset=utf-8";
                objRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; InfoPath.1; .NET CLR 2.0.50727; .NET CLR 1.1.4322)";

                #region افزودن هدر ها
                if (headers != null)
                    foreach (var item in headers)
                    {
                        objRequest.Headers.Add(item.Key, item.Value);
                    }
                #endregion

                objRequest.Headers.Add("Accept-charset", "ISO-8859-9,URF-8;q=0.7,*;q=0.7");
                objRequest.Headers["Accept-Encoding"] = "deflate";

                var response = (HttpWebResponse)(await objRequest.GetResponseAsync());

                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                string result = await sr.ReadToEndAsync();

                sr.Close();

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }
    }
}
