namespace PrancaBeauty.Application.Contracts.Setting
{
    public class OutSetting
    {
        /// <summary>
        /// مشخص کردن زبان
        /// </summary>
        public string LangCode { get; set; }
        public string SiteTitle { get; set; }
        public string SiteUrl { get; set; }
        public string SiteDescription { get; set; }
        public string SiteEmail { get; set; }
        public string SitePhoneNumber { get; set; }
        public bool IsInManufacture { get; set; }
    }
}
