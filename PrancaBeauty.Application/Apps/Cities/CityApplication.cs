using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Application.Contracts.City;
using PrancaBeauty.Application.Exceptions;
using PrancaBeauty.Domain.Region.CityAgg.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Cities
{
    public class CityApplication : ICityApplication
    {
        private readonly ICityRepository _cityRepository;
        private readonly ILogger _logger;

        public CityApplication(ICityRepository cityRepository, ILogger logger)
        {
            _cityRepository = cityRepository;
            _logger = logger;
        }

        public async Task<List<OutGetListForCombo>> GetListForComboAsync(string langId, string provinceId, string search)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(langId))
                    throw new ArgumentInvalidException($"'{nameof(langId)}' cannot be null or whitespace.");

                if (string.IsNullOrWhiteSpace(provinceId))
                    throw new ArgumentInvalidException($"'{nameof(provinceId)}' cannot be null or whitespace.");

                var qData = await _cityRepository.Get
                    .Where(a => a.IsActive)
                    .Where(a => a.ProvinceId == Guid.Parse(provinceId))
                    .Select(a => new OutGetListForCombo
                    {
                        Id = a.Id.ToString(),
                        Name = a.Name,
                        Title = a.TblCities_Translates.Where(b => b.LangId == Guid.Parse(langId)).Select(b => b.Title).Single()
                    })
                    .Where(a => search == null || a.Title.Contains(search))
                    .ToListAsync();

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


    }
}
