using PrancaBeauty.WebApp.Common.Utilities.Types;

namespace PrancaBeauty.WebApp.Common.Utilities.MessageBox
{
    public interface IMsgBox
    {
        JsResult ModelStateMsg(string modelErrors, string callBackFuncs = null);
    }
}
