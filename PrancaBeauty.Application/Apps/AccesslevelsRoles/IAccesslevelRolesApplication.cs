using PrancaBeauty.Application.Contracts.Result;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.AccesslevelsRoles
{
    public interface IAccesslevelRolesApplication
    {
        Task<OperationResult> RemoveByAccessLevelIdAsync(string accessLevelId);
    }
}
