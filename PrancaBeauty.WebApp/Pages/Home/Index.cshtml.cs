using Framework.Application.Consts;
using Framework.Common.ExMethod;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PrancaBeauty.WebApp.Pages.Home
{
    public class IndexModel : PageModel
    {

        private readonly ILocalizer _localizer;

        public IndexModel(ILocalizer localizer)
        {
            _localizer = localizer;
        }

        public void OnGet()
        {
            var msg = _localizer["Hello"];

            var txt = "{\"FtpHost\":\"ftp://127.0.0.3\",\"FtpPort\":21,\"FtpPath\":\"/\",\"FtpUserName\":\"Arsham\",\"FtpPassword\":\"1\"}";
            var res = txt.AesEncrypt(AuthConst.SecretKey);

        }
    }
}
