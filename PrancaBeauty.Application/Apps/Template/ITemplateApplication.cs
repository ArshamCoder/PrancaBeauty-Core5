using System.Threading.Tasks;

namespace PrancaBeauty.Application.Apps.Template
{
    public interface ITemplateApplication
    {

        Task<string> GetEmailConfirmationTemplateAsync(string langCode, string url);
        Task<string> GetTemplateAsync(string langCode, string name);
    }
}
