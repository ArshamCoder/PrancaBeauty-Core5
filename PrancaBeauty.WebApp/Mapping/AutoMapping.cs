using AutoMapper;
using PrancaBeauty.Application.Contracts.Users;
using PrancaBeauty.WebApp.Models.ViewInput;

namespace PrancaBeauty.WebApp.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ViCompo_AccountSettings, InpSaveAccountSettingUserDetails>().ReverseMap();
            //CreateMap<OutGetAddressByUserIdForManage, vmCompo_ListAddress>();
            //CreateMap<PrancaBeauty.Application.Contracts.Countries.OutGetListForCombo, vmCompo_Combo_Countries>();
            //CreateMap<PrancaBeauty.Application.Contracts.Province.OutGetListForCombo, vmCompo_Combo_Province>();
            //CreateMap<PrancaBeauty.Application.Contracts.City.OutGetListForCombo, vmCompo_Combo_Cities>();
        }
    }
}
