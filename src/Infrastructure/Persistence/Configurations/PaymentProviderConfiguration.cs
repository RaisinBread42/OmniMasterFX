using System;
using System.Collections.Generic;
using System.Text;
using OmniMasterFX.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OmniMasterFX.Persistence.Configurations
{
    public class PaymentProviderConfiguration : IEntityTypeConfiguration<PaymentProvider>
    {
        public void Configure(EntityTypeBuilder<PaymentProvider> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
