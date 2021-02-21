using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Accesslevel
{
    public interface IAccesslevelApplication
    {
        Task<string> GetIdByNameAsync(string name);
    }
}
