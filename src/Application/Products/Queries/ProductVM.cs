using OmniMasterFX.Application.Products.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace OmniMasterFX.Application.Models
{
    public class ProductVM
    {
        public ProductDTO ProductDTO { get; set; }
        public bool CanEdit { get; set; }
        public bool CanArchive { get; set; }
    }
}
