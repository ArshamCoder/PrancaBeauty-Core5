﻿using System;

namespace PrancaBeauty.Application.Contracts.Users
{
    public class OutGetUserDetailsForAccountSettings
    {
        public string LangId { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}