using System.ComponentModel.DataAnnotations;

namespace PrancaBeauty.WebApp.Models.ViewInput
{
    public class viCompo_Combo_Province
    {
        [Required]
        public string CountryId { get; set; }
        public string ProvinceId { get; set; }
        public string FieldName { get; set; }
    }
}
