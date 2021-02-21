using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Domain.User.AccessLevelAgg.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Accesslevel
{
    public class AccesslevelApplication : IAccesslevelApplication
    {
        private readonly IAccessLevelRepository _accessLevelRepository;

        public AccesslevelApplication(IAccessLevelRepository accessLevelRepository)
        {
            _accessLevelRepository = accessLevelRepository;
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
    }
}
