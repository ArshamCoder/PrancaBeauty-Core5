using System.Collections.Generic;
using System.Threading.Tasks;
using PrancaBeauty.Application.Contracts.City;

namespace PrancaBeauty.Application.Apps.Cities
{
    public interface ICityApplication
    {
        Task<List<OutGetListForCombo>> GetListForComboAsync(string langId, string provinceId, string search);
    }
}