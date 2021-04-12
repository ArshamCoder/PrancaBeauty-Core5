using System.ComponentModel.DataAnnotations;

namespace PrancaBeauty.Application.Contracts.AccessLevel
{
    /// <summary>
    /// سطوح دسترسی را برمیگرداند
    /// </summary>
    public class OutGetListForAdminPage
    {
        public string Id { get; set; }

        [Display(Name = "Title")]
        public string Name { get; set; }

        /// <summary>
        /// تعداد کاربرانی که عضو این سطح دسترسی هستند
        /// </summary>
        [Display(Name = "CountUser")]
        public int CountUser { get; set; }
    }
}
