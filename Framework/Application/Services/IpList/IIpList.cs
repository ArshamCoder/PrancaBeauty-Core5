namespace Framework.Application.Services.IpList
{
    public interface IIpList
    {
        void AddRange(string fromIP, string toIP);
        bool CheckNumber(string ipNumber);
    }
}
