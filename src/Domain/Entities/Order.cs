using OmniMasterFX.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace OmniMasterFX.Domain.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public long DeliveryProviderId { get; set; }
        public string OrderNumber { get; set; }
        public bool Paid { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool Enabled { get; set; }

        public Customer Customer { get; set; }
    }
}
