﻿using AutoMapper;
using Framework.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrancaBeauty.Application.Apps.Categories;
using PrancaBeauty.Application.Apps.Language;
using PrancaBeauty.Application.Contracts.Categories;
using PrancaBeauty.WebApp.Authentication;
using PrancaBeauty.WebApp.Common.ExMethod;
using PrancaBeauty.WebApp.Common.Utilities.MessageBox;
using PrancaBeauty.WebApp.Models.ViewInput;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Pages.Admin.Categories
{
    [Authorize(Roles = Roles.CanEditCategory)]
    public class EditModel : PageModel
    {
        private readonly IMsgBox _MsgBox;
        private readonly ILogger _Logger;
        private readonly IMapper _Mapper;
        private readonly ILocalizer _Localizer;
        private readonly ICategoryApplication _CategoryApplication;
        private readonly ILanguageApplication _LanguageApplication;
        public EditModel(ICategoryApplication categoryApplication, ILanguageApplication languageApplication, IMsgBox msgBox, IMapper mapper, ILocalizer localizer, ILogger logger)
        {
            _CategoryApplication = categoryApplication;
            _LanguageApplication = languageApplication;
            _MsgBox = msgBox;
            _Mapper = mapper;
            _Localizer = localizer;
            _Logger = logger;
        }

        public async Task<IActionResult> OnGetAsync(string ReturnUrl)
        {
            try
            {
                ViewData["ReturnUrl"] = ReturnUrl ?? $"/{CultureInfo.CurrentCulture.Parent.Name}/Admin/Category/List";

                var qData = await _CategoryApplication.GetForEditAsync(Input.Id);
                Input = _Mapper.Map<viEditCategory>(qData);

                var qLang = await _LanguageApplication.GetAllLanguageForSiteLangAsync();
                foreach (var item in qLang)
                {
                    if (!Input.LstTranslate.Any(a => a.LangId == item.Id))
                        Input.LstTranslate.Add(new viEditCategory_Translate()
                        {
                            LangId = item.Id
                        });
                }

                return Page();
            }
            catch (Exception ex)
            {
                _Logger.Error(ex);
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                    return _MsgBox.ModelStateMsg(ModelState.GetErrors());

                var _Result = await _CategoryApplication.SaveEditAsync(_Mapper.Map<InpSaveEdit>(Input));
                if (_Result.IsSucceed)
                {
                    return _MsgBox.SuccessMsg(_Localizer[_Result.Message], "GotoList()");
                }
                else
                {
                    return _MsgBox.FaildMsg(_Localizer[_Result.Message]);
                }
            }
            catch (Exception ex)
            {
                _Logger.Error(ex);
                return _MsgBox.FaildMsg(_Localizer["Error500"]);
            }
        }

        [BindProperty(SupportsGet = true)]
        public viEditCategory Input { get; set; }
    }
}