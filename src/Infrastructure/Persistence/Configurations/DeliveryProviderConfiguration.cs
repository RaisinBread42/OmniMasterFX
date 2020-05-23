using OmniMasterFX.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OmniMasterFX.Persistence.Configurations
{
    public class DeliveryProviderConfiguration : IEntityTypeConfiguration<DeliveryProvider>
    {
        public void Configure(EntityTypeBuilder<DeliveryProvider> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
