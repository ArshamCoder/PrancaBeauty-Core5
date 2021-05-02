using System.Collections.Generic;
using System.Linq;

namespace PrancaBeauty.WebApp.Authentication
{
    public class CacheUsersToRebuildToken
    {
        private static List<string> UserIds { get; set; }

        public static void AddRange(List<string> usersId)
        {
            if (UserIds == null)
                UserIds = new List<string>();

            UserIds.AddRange(usersId);
        }

        public static bool Any(string userId)
        {
            if (UserIds == null)
                return false;

            return UserIds.Any(a => a == userId);
        }

        public static void Remove(string userId)
        {
            UserIds?.Remove(userId);
        }
    }
}
