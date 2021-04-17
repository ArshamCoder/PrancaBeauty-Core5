using PrancaBeauty.Domain.User.UserAgg.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrancaBeauty.Application.Contracts.Role;

namespace PrancaBeauty.Application.Apps.Role
{
    public interface IRoleApplication
    {
        Task<List<string>> GetRolesByUserAsync(TblUser user);
        Task<List<OutListOfRoles>> ListOfRolesAsync(string parentId = null);
    }
}
