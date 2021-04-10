namespace PrancaBeauty.Application.Contracts.AccessLevel
{
    /// <summary>
    /// سطوح دسترسی را برمیگرداند
    /// </summary>
    public class OutGetListForAdminPage
    {
        public string Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// تعداد کاربرانی که عضو این سطح دسترسی هستند
        /// </summary>
        public int CountUser { get; set; }
    }
}
