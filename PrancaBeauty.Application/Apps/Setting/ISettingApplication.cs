using PrancaBeauty.Application.Contracts.Setting;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Setting
{
    public interface ISettingApplication
    {
        Task<OutSetting> GetSettingAsync(string langCode);
        void ClearCache();
    }
}
