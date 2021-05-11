namespace PrancaBeauty.WebApp.Authentication
{
    public static class Roles
    {
        #region AccessLevels
        public const string CanManageAccessLevel = "CanManageAccessLevel";
        public const string CanViewListAccessLevel = "CanViewListAccessLevel";
        public const string CanAddAccessLevel = "CanAddAccessLevel";
        public const string CanEditAccessLevel = "CanEditAccessLevel";
        public const string CanRemoveAccessLevel = "CanRemoveAccessLevel";
        #endregion


        #region Users
        public const string CanManageUsers = "CanManageUsers";
        public const string CanViewListUsers = "CanViewListUsers";
        public const string CanAddUsers = "CanAddUsers";
        public const string CanEditUsers = "CanEditUsers";
        public const string CanRemoveUsers = "CanRemoveUsers";
        public const string CanChangeUsersStatus = "CanChangeUsersStatus";
        public const string CanChangeUsersAccessLevel = "CanChangeUsersAccessLevel";
        #endregion
    }
}
