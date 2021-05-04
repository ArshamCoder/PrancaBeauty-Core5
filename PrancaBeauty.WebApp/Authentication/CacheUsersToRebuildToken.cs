using System.Collections.Generic;
using System.Linq;

namespace PrancaBeauty.WebApp.Authentication
{
    public class CacheUsersToRebuildToken
    {
        private static List<string> UserIds { get; set; }

        public static void AddRange(List<string> usersId)
        {
            UserIds ??= new List<string>();

            UserIds.AddRange(usersId);
        }

        public static bool Any(string userId)
        {
            return UserIds != null && UserIds.Any(a => a == userId);
        }

        public static void Remove(string userId)
        {
            UserIds?.Remove(userId);
        }
    }
}
