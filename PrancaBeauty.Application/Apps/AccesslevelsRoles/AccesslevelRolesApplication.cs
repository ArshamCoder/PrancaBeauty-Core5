using Framework.Common.ExMethod;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Application.Apps.Role;
using PrancaBeauty.Application.Contracts.Result;
using PrancaBeauty.Application.Exceptions;
using PrancaBeauty.Domain.User.AccessLevelAgg.Contracts;
using PrancaBeauty.Domain.User.AccessLevelAgg.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.AccesslevelsRoles
{
    public class AccesslevelRolesApplication : IAccesslevelRolesApplication
    {

        private readonly ILogger _logger;
        private readonly IAccesslevelRolesRepository _accesslevelRolesRepository;
        private readonly IRoleApplication _roleApplication;
        public AccesslevelRolesApplication(IAccesslevelRolesRepository accesslevelRolesRepository, ILogger logger, IRoleApplication roleApplication)
        {
            _accesslevelRolesRepository = accesslevelRolesRepository;
            _logger = logger;
            _roleApplication = roleApplication;
        }

        public async Task<OperationResult> RemoveByAccessLevelIdAsync(string accessLevelId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(accessLevelId))
                    throw new ArgumentInvalidException("AccessLevelId cant be null.");

                // واکشی اطلاعات
                var qData = await _accesslevelRolesRepository.Get.Where(a => a.AccessLevelId == Guid.Parse(accessLevelId)).ToListAsync();
                if (qData.Count < 0)
                    return new OperationResult().Succeed();


                await _accesslevelRolesRepository.DeleteRengeAsync(qData, default, true);
                //foreach (var item in qData)
                //{
                //    // حذف رکورد ها
                //    await _accesslevelRolesRepository.DeleteAsync(item, default, false);
                //}

                //// ذخیره تغییرات
                //await _accesslevelRolesRepository.SaveChangeAsync();

                return new OperationResult().Succeed();
            }
            catch (ArgumentInvalidException ex)
            {
                return new OperationResult().Failed(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new OperationResult().Failed("Error500");
            }
        }

        public async Task<OperationResult> AddRolesToAccessLevelAsync(string accessLevelId, string[] rolesName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(accessLevelId))
                    throw new ArgumentInvalidException("AccessLevelId cant be null.");

                if (rolesName == null)
                    throw new ArgumentInvalidException("RolesName cant be null.");

                foreach (var item in rolesName)
                {
                    await _accesslevelRolesRepository.AddAsync(new TblAccessLevel_Role()
                    {
                        Id = new Guid().SequentialGuid(),
                        AccessLevelId = Guid.Parse(accessLevelId),
                        RoleId = Guid.Parse(await _roleApplication.GetIdByNameAsync(item))
                    }, default, false);
                }

                await _accesslevelRolesRepository.SaveChangeAsync();

                return new OperationResult().Succeed();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new OperationResult().Failed("Error500");
            }
        }
    }
}
