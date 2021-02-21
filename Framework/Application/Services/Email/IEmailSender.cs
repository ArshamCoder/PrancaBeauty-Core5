using System.Threading.Tasks;

namespace Framework.Application.Services.Email
{
    public interface IEmailSender
    {
        public bool Send(string to, string subject, string message);
        public Task SendAsync(string to, string subject, string message);

    }
}
