using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.Common.Utilities.Download
{
    public interface IDownloader
    {
        Task<string> GetHtmlFromPageAsync(string pageUrl, object data, Dictionary<string, string> headers);
    }
}
