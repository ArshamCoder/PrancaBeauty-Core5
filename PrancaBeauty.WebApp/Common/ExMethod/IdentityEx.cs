using PrancaBeauty.WebApp.Models.ViewInput;
using System;
using System.Linq;
using System.Security.Claims;

namespace PrancaBeauty.WebApp.Common.ExMethod
{
    public static class IdentityEx
    {
        public static VmGetUserDetail GetUserDetails(this ClaimsPrincipal user)
        {
            //if (!user.Identity.IsAuthenticated)
            //    throw new Exception();

            var userData = new VmGetUserDetail()
            {
                UserId = user.Claims.Where(a => a.Type == "nameidentifier").Select(a => a.Value).SingleOrDefault() ?? "",
                UserName = user.Claims.Where(a => a.Type == "name").Select(a => a.Value).SingleOrDefault() ?? "",
                Email = user.Claims.Where(a => a.Type == "email").Select(a => a.Value).SingleOrDefault() ?? "",
                MobileNumber = user.Claims.Where(a => a.Type == "mobilephone").Select(a => a.Value).SingleOrDefault() ?? "",
                GivenName = user.Claims.Where(a => a.Type == "givenname").Select(a => a.Value).SingleOrDefault() ?? "",
                Surname = user.Claims.Where(a => a.Type == "surname").Select(a => a.Value).SingleOrDefault() ?? "",
                AccessLevel = user.Claims.Where(a => a.Type == "AccessLevel").Select(a => a.Value).SingleOrDefault() ?? "",
                Date = DateTime.Parse(user.Claims.Where(a => a.Type == "Date").Select(a => a.Value).SingleOrDefault() ?? DateTime.MinValue.ToString()),
            };

            return userData;
        }
    }
}
