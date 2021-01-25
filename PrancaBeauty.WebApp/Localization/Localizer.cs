using Microsoft.Extensions.Localization;
using PrancaBeauty.WebApp.Localization.Resource;

namespace PrancaBeauty.WebApp.Localization
{
    public class Localizer : ILocalizer
    {
        public string this[string name] => Get(name);

        public string this[string name, params object[] arguments] => Get(name, arguments);

        private readonly IStringLocalizer _sharedLocalizer;

        public Localizer(IStringLocalizerFactory stringLocalizerFactory)
        {
            _sharedLocalizer = new FactoryLocalizer().Set(stringLocalizerFactory, typeof(SharedResource));
        }

        public Localizer(IStringLocalizer sharedLocalizer)
        {
            _sharedLocalizer = sharedLocalizer;
        }


        /// <summary>
        /// خواندن مقدار از فایل ریسورس
        /// </summary>
        private string Get(string name)
        {
            return _sharedLocalizer[name];
        }

        /// <summary>
        /// خواندن مقدار از فایل ریسورس
        /// </summary>
        private string Get(string name, params object[] arguments)
        {
            return _sharedLocalizer[name, arguments];
        }
    }
}
