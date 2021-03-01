using System.Threading.Tasks;

namespace PrancaBeauty.WebApp.Authentication.Jwt
{
    public interface IJwtBuilder
    {
        Task<string> CreateTokenAync(string userId);
    }
}
