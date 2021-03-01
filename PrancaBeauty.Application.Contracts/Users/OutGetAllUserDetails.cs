using System;

namespace PrancaBeauty.Application.Contracts.Users
{
    public class OutGetAllUserDetails
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccessLevelId { get; set; }
        public string AccessLevelTitle { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
    }
}
