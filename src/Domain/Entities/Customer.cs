﻿namespace OmniMasterFX.Domain.Entities
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WebsiteURL { get; set; }
        public bool Enabled { get; set; }
        public long PaymentProviderId { get; set; }

        public PaymentProvider PaymentProvider { get; set; }
    }
}