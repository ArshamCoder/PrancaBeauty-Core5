namespace Framework.Application.Services.Sms
{
    public interface ISmsSender
    {
        bool Send(string phoneNumber, string message);
        bool SendLoginCode(string phoneNumber, string code);
    }
}
