using System.ComponentModel.DataAnnotations;

namespace PrancaBeauty.WebApp.Models.ViewInput
{
    public class viCompo_Combo_Cities
    {
        [Required]
        public string ProvinceId { get; set; }
        public string CityId { get; set; }
        public string FieldName { get; set; }
    }
}
