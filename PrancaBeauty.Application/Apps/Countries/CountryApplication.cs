using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Application.Contracts.Province;
using PrancaBeauty.Application.Exceptions;
using PrancaBeauty.Domain.Region.CountryAgg.Contracts;
using PrancaBeauty.Domain.Region.ProvinceAgg.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Countries
{
    public class CountryApplication : ICountryApplication
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly ILogger _logger;

        public CountryApplication(ICountryRepository countryRepository, IProvinceRepository provinceRepository, ILogger logger)
        {
            _countryRepository = countryRepository;
            _provinceRepository = provinceRepository;
            _logger = logger;
        }

        public async Task<List<OutGetListForCombo>> GetListForComboAsync(string langId, string countryId, string search)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(langId))
                    throw new ArgumentInvalidException($"'{nameof(langId)}' cannot be null or whitespace.");

                if (string.IsNullOrWhiteSpace(countryId))
                    throw new ArgumentInvalidException($"'{nameof(countryId)}' cannot be null or whitespace.");

                var qData = await _provinceRepository.Get
                    .Where(a => a.IsActive)
                    .Where(a => a.CountryId == Guid.Parse(countryId))
                    .Select(a => new OutGetListForCombo
                    {
                        Id = a.Id.ToString(),
                        Name = a.Name,
                        Title = a.tblProvinces_Translate.Where(b => b.LangId == Guid.Parse(langId)).Select(b => b.Title).Single()
                    })
                    .Where(a => search == null || a.Title.Contains(search))
                    .ToListAsync();

                return qData;
            }
            catch (ArgumentInvalidException ex)
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
}
