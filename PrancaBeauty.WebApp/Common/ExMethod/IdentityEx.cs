﻿using PrancaBeauty.WebApp.Models.ViewInput;
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
                UserId = user.Claims.Where(a => a.Type == ClaimTypes.NameIdentifier).Select(a => a.Value).SingleOrDefault() ?? "",
                UserName = user.Claims.Where(a => a.Type == ClaimTypes.Name).Select(a => a.Value).SingleOrDefault() ?? "",
                Email = user.Claims.Where(a => a.Type == ClaimTypes.Email).Select(a => a.Value).SingleOrDefault() ?? "",
                MobileNumber = user.Claims.Where(a => a.Type == ClaimTypes.MobilePhone).Select(a => a.Value).SingleOrDefault() ?? "",
                GivenName = user.Claims.Where(a => a.Type == ClaimTypes.GivenName).Select(a => a.Value).SingleOrDefault() ?? "",
                Surname = user.Claims.Where(a => a.Type == ClaimTypes.Surname).Select(a => a.Value).SingleOrDefault() ?? "",
                AccessLevel = user.Claims.Where(a => a.Type == "AccessLevel").Select(a => a.Value).SingleOrDefault() ?? "",
                Date = DateTime.Parse(user.Claims.Where(a => a.Type == "Date").Select(a => a.Value).SingleOrDefault() ?? DateTime.MinValue.ToString()),
            };

            return userData;
        }
    }
}
