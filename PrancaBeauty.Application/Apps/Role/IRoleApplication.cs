using PrancaBeauty.Domain.User.UserAgg.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Role
{
    public interface IRoleApplication
    {
        Task<List<string>> GetRolesByUserAsync(TblUser user);
    }
}
