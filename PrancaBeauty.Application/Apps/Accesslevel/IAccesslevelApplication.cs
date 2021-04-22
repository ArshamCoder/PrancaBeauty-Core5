using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Common.Utilities.Paging;
using PrancaBeauty.Application.Contracts.AccessLevel;
using PrancaBeauty.Application.Contracts.Result;

namespace PrancaBeauty.Application.Apps.Accesslevel
{
    public interface IAccesslevelApplication
    {
        Task<string> GetIdByNameAsync(string name);

        Task<(OutPagingData, List<OutGetListForAdminPage>)>
            GetListForAdminPageAsync(string title, int pageNum, int take);

        Task<OperationResult> AddNewAsync(InpAddNewAccessLevel Input);
    }
}
