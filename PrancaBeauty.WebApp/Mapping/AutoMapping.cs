﻿using AutoMapper;
using PrancaBeauty.Application.Contracts.Address;
using PrancaBeauty.Application.Contracts.Categories;
using PrancaBeauty.Application.Contracts.Users;
using PrancaBeauty.WebApp.Models.ViewInput;
using PrancaBeauty.WebApp.Models.ViewModel;

namespace PrancaBeauty.WebApp.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ViCompo_AccountSettings, InpSaveAccountSettingUserDetails>().ReverseMap();
            CreateMap<ViCompo_AddAddress, InpAddAddress>();
            CreateMap<viCompo_EditAddress, InpEditAddress>();
            CreateMap<OutGetAddressDetails, viCompo_EditAddress>();
            CreateMap<OutGetAddressByUserIdForManage, VmCompo_ListAddress>().ReverseMap();
            CreateMap<PrancaBeauty.Application.Contracts.Countries.OutGetListForCombo, vmCompo_Combo_Countries>();
            CreateMap<PrancaBeauty.Application.Contracts.Province.OutGetListForCombo, vmCompo_Combo_Province>();
            CreateMap<PrancaBeauty.Application.Contracts.City.OutGetListForCombo, vmCompo_Combo_Cities>();
            CreateMap<PrancaBeauty.Application.Contracts.Categories.OutGetListForAdminPage, vmCategoriesList>();
            CreateMap<viAddCategory, InpAddCategory>();
            CreateMap<viAddCategory_Translate, InpAddCategory_Translate>();


            //CreateMap<viCompo_AccountSettings, InpSaveAccountSettingUserDetails>();
            //CreateMap<OutGetAddressByUserIdForManage, vmCompo_ListAddress>();

            //CreateMap<PrancaBeauty.Application.Contracts.Categories.OutGetListForCombo, vmCompo_Combo_Categories>();






        }
    }
}
