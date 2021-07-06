using System.Collections.Generic;
using System.Threading.Tasks;
using PrancaBeauty.Application.Contracts.Province;

namespace PrancaBeauty.Application.Apps.Province
{
    public interface IProvinceApplication
    {
        Task<List<OutGetListForCombo>> GetListForComboAsync(string langId, string countryId, string search);
    }
}