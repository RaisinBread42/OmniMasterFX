using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using OmniMasterFX.Domain.Entities;
using OmniMasterFX.Application.Common.Mappings;

namespace OmniMasterFX.Application.Products.Queries
{
    public class ProductDTO : IMapFrom<Product>
    {
        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Product, ProductDTO>()
            //    .ForMember(d => d.SupplierCompanyName, opt => opt.MapFrom(s => s.Supplier != null ? s.Supplier.CompanyName : string.Empty))
            //    .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Category != null ? s.Category.CategoryName : string.Empty));
        }
    }
}
