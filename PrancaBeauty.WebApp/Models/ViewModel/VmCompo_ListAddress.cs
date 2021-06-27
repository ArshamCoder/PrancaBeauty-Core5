using System.ComponentModel.DataAnnotations;

namespace PrancaBeauty.WebApp.Models.ViewModel
{
    public class VmCompo_ListAddress
    {
        public string Id { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "CountBills")]
        public int CountBills { get; set; }
    }
}
