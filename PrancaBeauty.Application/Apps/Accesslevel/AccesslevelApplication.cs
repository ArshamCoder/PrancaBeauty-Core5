using Framework.Common.Utilities.Paging;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Application.Contracts.AccessLevel;
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
    }
}
