using System;
using System.Collections.Generic;
using System.Text;

namespace OmniMasterFX.Domain.Entities
{
    public class ProductCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long PictureId { get; set; }
        public bool Enabled { get; set; }

        public Picture Picture { get; set; }
        public ICollection<ProductSubCategory> ProductSubCategories { get; set; }
    }
}
