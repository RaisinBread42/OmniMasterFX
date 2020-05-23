namespace OmniMasterFX.Domain.Entities
{
    public class VendorSubCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long PictureId { get; set;}
        public bool Enabled { get; set; }
        public long VendorCategoryId { get; set; }

        public Picture Picture { get; set; }
        public VendorCategory VendorCategory { get; set; }
    }
}