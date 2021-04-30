using PrancaBeauty.Domain.User.UserAgg.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrancaBeauty.Application.Contracts.Roles;

namespace PrancaBeauty.Application.Apps.Role
{
    public interface IRoleApplication
    {
        Task<List<string>> GetRolesByUserAsync(TblUser user);
        Task<List<OutListOfRoles>> ListOfRolesAsync(string ParentId = null);
        Task<string[]> ListOfRolesByAccessLevelIdAsync(string accessLevelId);
    }
}
