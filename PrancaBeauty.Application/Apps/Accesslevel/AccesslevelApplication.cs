﻿using Framework.Common.Utilities.Paging;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Application.Contracts.AccessLevel;
using PrancaBeauty.Application.Contracts.Result;
using PrancaBeauty.Application.Exceptions;
using PrancaBeauty.Domain.User.AccessLevelAgg.Contracts;
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

                //await _accessLevelRepository.AddAsync(new TblAccessLevels
                //{
                //    Id = new Guid().SequentialGuid(),
                //    Name = Input.Name,
                //    TblAccessLevel_Roles = Input.Roles.Select(roleId => new TblAccessLevel_Role()
                //    {
                //        Id = new Guid().SequentialGuid(),
                //        RoleId = Guid.Parse(roleId)
                //    }).ToList()
                //}, default, true);

                //return new OperationResult().Succeeded();

                return default;
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





    }
}
