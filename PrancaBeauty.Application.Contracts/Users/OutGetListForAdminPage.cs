using System;

namespace PrancaBeauty.Application.Contracts.Users
{
    public class OutGetListForAdminPage
    {
        public string Id { get; set; }
        public string AccessLevelId { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string AccessLevelName { get; set; }

        public DateTime Date { get; set; }

        public bool IsActive { get; set; }


        public bool IsEmailConfirmed { get; set; }

        public bool IsPhoneNumberConfirmed { get; set; }
    }
}
