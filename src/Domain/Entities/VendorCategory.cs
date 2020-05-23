using System.Collections.Generic;

namespace OmniMasterFX.Domain.Entities
{
    public class VendorCategory
    {
        public long Id { get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public long PictureId { get; set; }
        public bool Enabled { get; set; }

        public Picture Picture { get; set; }
        public ICollection<VendorSubCategory> VendorSubCategories { get; set; }
    }
}