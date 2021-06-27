using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Common.Utilities.Paging;
using PrancaBeauty.Application.Contracts.Address;
using PrancaBeauty.Application.Contracts.Result;

namespace PrancaBeauty.Application.Apps.Address
{
    public interface IAddressApplication
    {
        Task<(OutPagingData, List<OutGetAddressByUserIdForManage>)> GetAddressByUserIdForManageAsync(string UserId, string LangId, string Search, int PageNum, int Take);
        Task<OperationResult> AddAddressAsync(InpAddAddress Input);
        Task<OperationResult> RemoveAddressAsync(string UserId, string Id);
        Task<OutGetAddressDetails> GetAddressDetailsAsync(string UserId, string Id);
        Task<OperationResult> EditAddressAsync(InpEditAddress Input);
    }
}
