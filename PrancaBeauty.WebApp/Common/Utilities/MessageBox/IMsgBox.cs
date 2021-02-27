namespace PrancaBeauty.WebApp.Common.Utilities.MessageBox
{
    public interface IMsgBox
    {
        string ModelStateMsg(string modelErrors, string callBackFuncs = null);
    }
}
