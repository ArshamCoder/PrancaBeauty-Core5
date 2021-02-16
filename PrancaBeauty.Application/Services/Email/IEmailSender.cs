using System.Threading.Tasks;

namespace PrancaBeauty.Application.Services.Email
{
    public interface IEmailSender
    {
        public bool Send(string to, string subject, string message);
        public Task SendAsync(string to, string subject, string message);

    }
}
