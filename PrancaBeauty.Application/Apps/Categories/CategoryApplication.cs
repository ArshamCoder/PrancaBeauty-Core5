using Framework.Common.ExMethod;
using Framework.Common.Utilities.Paging;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PrancaBeauty.Application.Contracts.Categories;
using PrancaBeauty.Application.Contracts.Result;
using PrancaBeauty.Application.Exceptions;
using PrancaBeauty.Domain.Categories.Contracts;
using PrancaBeauty.Domain.Categories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Categories
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ILogger _Logger;
        //private readonly IFtpWapper _FtpWapper;
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryApplication(ILogger logger, ICategoryRepository categoryRepository)
        {
            _Logger = logger;
            _CategoryRepository = categoryRepository;
        }

        public async Task<(OutPagingData, List<OutGetListForAdminPage>)> GetListForAdminPageAsync(string LangId, string Title, string ParentTitle, int PageNum, int Take)
        {
            try
            {
                if (PageNum < 1)
                    throw new ArgumentInvalidException("PageNum < 1");

                if (Take < 1)
                    throw new ArgumentInvalidException("Take < 1");

                Title = string.IsNullOrWhiteSpace(Title) ? null : Title;

                // آماده سازی اولیه ی کویری
                var qData = _CategoryRepository.Get.Select(a => new OutGetListForAdminPage
                {
                    Id = a.Id.ToString(),
                    ParentId = a.ParentId.ToString(),
                    Name = a.Name,
                    Title = a.tblCategory_Translates.Where(b => b.LangId == Guid.Parse(LangId)).Select(b => b.Title).Single(),
                    ImgUrl = a.tblFiles.TblFileServer.HttpDomin
                                + a.tblFiles.TblFileServer.HttpPath
                                + a.tblFiles.Path
                                + a.tblFiles.FileName,
                    Sort = a.Sort,
                    ParentTitle = a.tblCategory_Parent.tblCategory_Translates.Where(b => b.LangId == Guid.Parse(LangId)).Select(b => b.Title).Single(),
                })
                .Where(a => Title == null || a.Title.Contains(Title))
                .Where(a => ParentTitle == null || a.ParentTitle.Contains(ParentTitle))
                .OrderBy(a => a.ParentId)
                .ThenBy(a => a.Sort);

                // صفحه بندی داده ها
                var qPagingData = PagingData.Calc(await qData.LongCountAsync(), PageNum, Take);

                return (qPagingData, await qData.Skip((int)qPagingData.Skip).Take(qPagingData.Take).ToListAsync());
            }
            catch (ArgumentInvalidException)
            {
                return (null, null);
            }
            catch (Exception ex)
            {
                _Logger.Error(ex);
                return (null, null);
            }
        }

        public async Task<List<OutGetListForCombo>> GetListForComboAsync(string LangId, string ParentId)
        {
            var qData = await _CategoryRepository.Get
                                                 .Where(a => ParentId != null ? a.ParentId == Guid.Parse(ParentId) /*&& a.Id != Guid.Parse(ParentId)*/ : a.ParentId == null)
                                                .Select(a => new OutGetListForCombo
                                                {
                                                    Id = a.Id.ToString(),
                                                    ParentId = a.ParentId.ToString(),
                                                    Name = a.Name,
                                                    Title = a.tblCategory_Translates.Where(b => b.LangId == Guid.Parse(LangId)).Select(b => b.Title).Single(),
                                                    Sort = a.Sort,
                                                    hasChildren = a.tblCategory_Childs/*.Where(b => b.Id != Guid.Parse(ParentId))*/.Any(),
                                                    ImgUrl = a.tblFiles.TblFileServer.HttpDomin
                                                                + a.tblFiles.TblFileServer.HttpPath
                                                                + a.tblFiles.Path
                                                                + a.tblFiles.FileName,
                                                })
                                                .ToListAsync();

            return qData;
        }

        public async Task<OperationResult> AddCategoryAsync(InpAddCategory Input)
        {
            try
            {
                if (Input is null)
                    throw new ArgumentInvalidException("Input cant be null.");

                if (await _CategoryRepository.Get.AnyAsync(a => a.ParentId == (Input.ParentId != null ? Guid.Parse(Input.ParentId) : null) && a.Name == Input.Name))
                    return new OperationResult().Failed("CategoryName Is Duplicate.");

                var tCategory = new TblCategoris()
                {
                    Id = new Guid().SequentialGuid(),
                    ParentId = Input.ParentId != null ? Guid.Parse(Input.ParentId) : null,
                    Name = Input.Name,
                    Sort = Input.Sort,
                    tblCategory_Translates = new List<TblCategory_Translates>()
                };

                foreach (var item in Input.LstTranslate)
                {
                    tCategory.tblCategory_Translates.Add(new TblCategory_Translates()
                    {
                        Id = new Guid().SequentialGuid(),
                        LangId = Guid.Parse(item.LangId),
                        Title = item.Title,
                        Description = item.Description
                    });
                }

                //var FileUploadResult = await _FtpWapper.UplaodCategoryImgAsync(Input.Image, Input.Name);
                //if (FileUploadResult == null)
                //    return new OperationResult().Failed("Error500");

                // tCategory.ImageId = Guid.Parse(FileUploadResult);
                await _CategoryRepository.AddAsync(tCategory, default, true);

                return new OperationResult().Succeed();
            }
            catch (ArgumentInvalidException ex)
            {
                return new OperationResult().Failed(ex.Message);
            }
            catch (Exception ex)
            {
                _Logger.Error(ex);
                return new OperationResult().Failed("Error500");
            }
        }
    }
}
