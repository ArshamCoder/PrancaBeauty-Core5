using Framework.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Application.Contracts.Roles;
using PrancaBeauty.Application.Exceptions;
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
                .Select(a => new OutListOfRoles
                {
                    Id = a.Id.ToString(),
                    Name = a.Name,
                    PageName = a.PageName,
                    Description = a.Description,
                    Sort = a.Sort,
                    HasChild = a.tblRoles_Childs.Any(),
                    ParentId = a.ParentId.HasValue ? a.ParentId.Value.ToString() : null
                })
                .ToListAsync();

            return qData;

        }
        public async Task<string[]> ListOfRolesByAccessLevelIdAsync(string accessLevelId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(accessLevelId))
                    throw new ArgumentInvalidException("AccessLevelId cant be null.");

                var qData = await _roleManager.Roles
                    .Where(a => a.TblAccessLevel_Roles.Any(b => b.AccessLevelId == Guid.Parse(accessLevelId)))
                    .Select(a => a.Name.ToString())
                    .ToArrayAsync();

                return qData;
            }
            catch (ArgumentInvalidException)
            {
                return null;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return null;
            }
        }

        public async Task<string> GetIdByNameAsync(string name)
        {
            return await _roleRepository.Get.Where(a => a.Name == name).Select(a => a.Id.ToString()).SingleOrDefaultAsync();
        }






    }
}
