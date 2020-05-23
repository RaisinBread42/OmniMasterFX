using System;
using System.Collections.Generic;
using System.Text;
using OmniMasterFX.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OmniMasterFX.Infrastructure.Persistence.Configurations
{
    public class PrimaryMenuItemConfigurations: IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
