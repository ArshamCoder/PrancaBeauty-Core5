using Framework.Common.ExMethod;
using Framework.Common.Utilities.Paging;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Application.Contracts.AccessLevel;
using PrancaBeauty.Application.Contracts.Result;
using PrancaBeauty.Application.Exceptions;
using PrancaBeauty.Domain.User.AccessLevelAgg.Contracts;
using PrancaBeauty.Domain.User.AccessLevelAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Accesslevel
{
    public class AccesslevelApplication : IAccesslevelApplication
    {
        private readonly IAccessLevelRepository _accessLevelRepository;
        private readonly ILogger _logger;
        public AccesslevelApplication(IAccessLevelRepository accessLevelRepository, ILogger logger)
        {
            _accessLevelRepository = accessLevelRepository;
            _logger = logger;
        }
        public async Task<string> GetIdByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Name cant be null.");

            var qData = await _accessLevelRepository.GetNoTraking
                .Where(a => a.Name == name).Select(a => a.Id.ToString()).SingleOrDefaultAsync();

            if (qData == null)
                return Guid.Empty.ToString();

            return qData;
        }


        public async Task<(OutPagingData, List<OutGetListForAdminPage>)>
            GetListForAdminPageAsync(string title, int pageNum, int take)
        {
            try
            {
                if (pageNum < 1)
                    throw new Exception("PageNum < 1");

                if (take < 1)
                    throw new Exception("Take < 1");

                title = string.IsNullOrWhiteSpace(title) ? null : title;

                // آماده سازی اولیه ی کویری
                var qData = _accessLevelRepository.Get.Select(a => new OutGetListForAdminPage
                {
                    Id = a.Id.ToString(),
                    Name = a.Name,
                    CountUser = a.TblUsers.Count()
                })
                    //.Where(a => title != null ? a.Name.Contains(title) : true) //بهینه شده این خط در خط پایین هست
                    .Where(a => title == null || a.Name.Contains(title))
                    .OrderBy(a => a.Name);

                // صفحه بندی داده ها
                var qPagingData = PagingData.Calc(await qData.LongCountAsync(), pageNum, take);

                return (qPagingData, await qData.Skip((int)qPagingData.Skip).Take(qPagingData.Take).ToListAsync());
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return (null, null);
            }

        }


        public async Task<OperationResult> AddNewAsync(InpAddNewAccessLevel Input)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Input.Name))
                    throw new ArgumentInvalidException("Name cant be null.", new ArgumentNullException());

                if (Input.Roles == null)
                    throw new ArgumentInvalidException("Roles cant be null.", new ArgumentNullException());

                if (await _accessLevelRepository.Get.AnyAsync(a => a.Name == Input.Name))
                    throw new ArgumentInvalidException("Name is duplicate.", new ArgumentNullException());

                await _accessLevelRepository.AddAsync(new TblAccessLevels
                {
                    Id = new Guid().SequentialGuid(),
                    Name = Input.Name,
                    TblAccessLevel_Roles = Input.Roles.Select(roleId => new TblAccessLevel_Role()
                    {
                        Id = new Guid().SequentialGuid(),
                        RoleId = Guid.Parse(roleId)
                    }).ToList()
                }, default, true);

                return new OperationResult().Succeed();


            }
            catch (ArgumentInvalidException ex)
            {
                // مثلا یکی با گوشی موبایل میخواد به 
                // api
                // سایت وصل بشه و نام وارد نمیکنه فقط این پیغام خطا بهش نشون میدیم که بفهمه
                // دیگه نیازی نیست لاگ بندازیم توی دیتابیس چون این نوع 
                // خطا ها مدیریت شده هستند
                return new OperationResult().Failed(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new OperationResult().Failed("Error500");
            }
        }

        public async Task<OutGetForEdit> GetForEditAsync(string accessLevelId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(accessLevelId))
                    throw new ArgumentInvalidException("AccessLevelId cant be null.");

                return await _accessLevelRepository.Get
                    .Where(a => a.Id == Guid.Parse(accessLevelId))
                    .Select(a => new OutGetForEdit
                    {
                        Id = a.Id.ToString(),
                        Name = a.Name
                    })
                    .SingleOrDefaultAsync();
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

        public async Task<OperationResult> RemoveAsync(InpRemove input)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input.Id))
                    throw new ArgumentInvalidException("Id cant be null.");

                // واکشی سطح دسترسی
                var qData = await _accessLevelRepository.Get.Where(a => a.Id == Guid.Parse(input.Id)).SingleOrDefaultAsync();
                if (qData == null)
                    return new OperationResult().Failed("AccessLevelNotFound");

                // برسی عضو بودن کاربر در سطح دسترسی جاری
                // پس وقتی که کاربری این سطح دسترسی دارد
                // مدیر نباید اجازه داشته باشید که سطح دسترسی پاک کند
                if (await CheckHasUserAsync(input.Id))
                    return new OperationResult().Failed("AccessLevelHasUser");

                // حذف کامل سطح دسترسی
                await _accessLevelRepository.DeleteAsync(qData, default, true);

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

        private async Task<bool> CheckHasUserAsync(string accessLevelId)
        {
            //چک میکند که کاربر در این سطح دسترسی عضو هست یا خیر
            return await _accessLevelRepository.Get
                .Where(a => a.Id == Guid.Parse(accessLevelId))
                .Select(a => a.TblUsers.Any())
                .SingleAsync();
        }

    }
}
