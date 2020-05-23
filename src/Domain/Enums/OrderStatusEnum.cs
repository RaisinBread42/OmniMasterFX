using System;
using System.Collections.Generic;
using System.Text;

namespace OmniMasterFX.Domain.Enumerations
{
    public enum OrderStatus
    {
        Pending, 
        Submitted,
        Processing,
        OutForDelivery,
        Delivered,
        Completed,
    }
}
