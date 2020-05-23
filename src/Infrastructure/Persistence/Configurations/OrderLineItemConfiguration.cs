using System;
using System.Collections.Generic;
using System.Text;
using OmniMasterFX.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OmniMasterFX.Persistence.Configurations
{
    public class OrderLineItemConfigurations : IEntityTypeConfiguration<OrderLineItem>
    {
        public void Configure(EntityTypeBuilder<OrderLineItem> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
