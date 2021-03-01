using PrancaBeauty.WebApp.Common.Utilities.Types;

namespace PrancaBeauty.WebApp.Common.Utilities.MessageBox
{
    public interface IMsgBox
    {
        JsResult ModelStateMsg(string modelErrors, string callBackFuncs = null);
        JsResult FaildMsg(string message, string callBackFuncs = null);
        JsResult InfoMsg(string message, string callBackFuncs = null);
    }
}
