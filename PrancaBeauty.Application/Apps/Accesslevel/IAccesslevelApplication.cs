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
        Task<OperationResult> RemoveAsync(InpRemove input);
        Task<OutGetForEdit> GetForEditAsync(string accessLevelId);
        Task<OperationResult> UpdateAsync(InpUpdateAccessLevel input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name">بخشی از نام برای جستوجو</param>
        /// <returns></returns>
        Task<List<OutGetForChangeUserAccesssLevel>> GetForChangeUserAccesssLevelAsync(string Name);
    }
}
