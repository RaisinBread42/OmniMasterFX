using System;
using System.Collections.Generic;
using System.Text;

namespace OmniMasterFX.Domain.Entities
{
    public class OrderLineItem
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string TrackingNumber { get; set; }
        public string SKU { get; set; }
        public long SizeId { get; set; }
        public long ColorId { get; set; }
        public int Quantity { get; set; }
        public bool Fulfilled { get; set; }
        public DateTime DeliverySentDate { get; set; }
        public DateTime DeliveryReceivedDate { get; set; }

        public Order Order { get; set; }
        public ProductSize Size { get; set; }
        public Color Color { get; set; }
    }
}
