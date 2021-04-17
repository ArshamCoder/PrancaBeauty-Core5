using Framework.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Application.Contracts.Role;
using PrancaBeauty.Domain.User.RoleAgg.Contracts;
using PrancaBeauty.Domain.User.RoleAgg.Entities;
using PrancaBeauty.Domain.User.UserAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Role
{
    public class RoleApplication : IRoleApplication
    {
        private readonly ILogger _logger;
        private readonly IRoleRepository _roleRepository;
        private readonly RoleManager<TblRole> _roleManager;
        private readonly UserManager<TblUser> _userManager;

        public RoleApplication(ILogger logger, IRoleRepository roleRepository, RoleManager<TblRole> roleManager, UserManager<TblUser> userManager)
        {
            _logger = logger;
            _roleRepository = roleRepository;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<List<string>> GetRolesByUserAsync(TblUser user)
        {
            try
            {
                if (user == null)
                    throw new ArgumentNullException("User cant be null.");

                return (await _userManager.GetRolesAsync(user)).ToList();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }

        public async Task<List<OutListOfRoles>> ListOfRolesAsync(string parentId = null)
        {


            var qData = await _roleManager.Roles
                .Where(a => a.ParentId == (parentId == null ? (Guid?)null : Guid.Parse(parentId)))
                .Select(x => new OutListOfRoles
                {
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    PageName = x.PageName,
                    Description = x.Description,
                    Sort = x.Sort,
                    HasChild = x.TblRoleChild.Any(),
                    ParentId = x.ParentId.HasValue ? x.ParentId.Value.ToString() : null
                })
                .ToListAsync();

            return qData;

        }

    }
}
