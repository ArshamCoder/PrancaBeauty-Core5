using Microsoft.AspNetCore.Mvc;

namespace PrancaBeauty.WebApp.Common.Utilities.Types
{
    public class JsResult : ContentResult
    {
        public JsResult(string script)
        {
            Content = script;
            ContentType = "application/javascript";
        }
    }
}
