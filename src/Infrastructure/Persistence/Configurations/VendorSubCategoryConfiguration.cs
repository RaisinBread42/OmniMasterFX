using System;
using System.Collections.Generic;
using System.Text;
using OmniMasterFX.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OmniMasterFX.Persistence.Configurations
{
    public class VendorSubCategoryConfiguration : IEntityTypeConfiguration<VendorSubCategory>
    {
        public void Configure(EntityTypeBuilder<VendorSubCategory> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
