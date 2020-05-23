using System;
using System.Collections.Generic;
using System.Text;
using OmniMasterFX.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OmniMasterFX.Persistence.Configurations
{
    public class VendorCategoryConfiguration : IEntityTypeConfiguration<VendorCategory>
    {
        public void Configure(EntityTypeBuilder<VendorCategory> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
