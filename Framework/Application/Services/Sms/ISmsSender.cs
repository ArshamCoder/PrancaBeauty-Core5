namespace Framework.Application.Services.Sms
{
    public interface ISmsSender
    {
        public bool Send(string phoneNumber, string message);
    }
}
