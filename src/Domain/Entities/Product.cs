using System;
using System.Collections.Generic;
using System.Text;

namespace OmniMasterFX.Domain.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int InventoryQuantity { get; set; }
        public int ReorderLevel { get; set; }
        public float UnitPrice { get; set; }
        public long VendorId { get; set; }
        public long ProductSubCategoryId { get; set; }
        public long SizeId { get; set; }
        public long ColorId { get; set; }
        public float DiscountPrice { get; set; }
        public int QuantityPerUnit { get; set; }
        public float UnitHeight { get; set; }
        public float UnitWidth { get; set; }
        public float UnitLength { get; set; }
        public long PictureId { get; set; }
        public float Rating { get; set; }
        public bool Enabled { get; set; }
    
        public ProductSize Size { get; set; }
        public Color Color { get; set; }
        public Picture Picture { get; set; }
    }
}
