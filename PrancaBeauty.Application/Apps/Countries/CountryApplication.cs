using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Application.Contracts.Countries;
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

        public async Task<List<OutGetListForCombo>> GetListForComboAsync(string langId, string search)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(langId))
                    throw new ArgumentInvalidException($"'{nameof(langId)}' cannot be null or whitespace.");

                var qData = await _countryRepository.Get
                    .Where(a => a.IsActive)
                    .Select(a => new OutGetListForCombo
                    {
                        Id = a.Id.ToString(),
                        Name = a.Name,
                        Title = a.tblCountries_Translates.Where(b => b.LangId == Guid.Parse(langId)).Select(b => b.Title).Single(),
                        FlagUrl = a.tblFiles.TblFileServer.HttpDomin +
                                  a.tblFiles.TblFileServer.HttpPath +
                                  a.tblFiles.Path +
                                  a.tblFiles.FileName
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
