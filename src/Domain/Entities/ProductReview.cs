using System;
using System.Collections.Generic;
using System.Text;

namespace OmniMasterFX.Domain.Entities
{
    public class ProductReview
    {
        public long Id { get; set; }
        public float RatingScore { get; set;}
        public string Comment { get; set; }
        public long CustomerId { get; set; }
        public bool Enabled { get; set; }
        public float ReviewPositivityScore { get; set; }
        public float ReviewNegativityScore { get; set; }
    }
}
