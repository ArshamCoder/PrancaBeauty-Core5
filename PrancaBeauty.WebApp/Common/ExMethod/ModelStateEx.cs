using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace PrancaBeauty.WebApp.Common.ExMethod
{
    public static class ModelStateEx
    {
        public static string GetErrors(this ModelStateDictionary modelState, string separator = "<br/>")
        {
            var message = string.Join(separator,
                modelState.Values.SelectMany(x => x.Errors.Select(x => x.ErrorMessage)));
            return message;
        }

    }
}
