using OmniMasterFX.Application.Common.Interfaces;
using OmniMasterFX.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OmniMasterFX.Application.Products.Commands
{
    public class CreateProductCommand : IRequest<Product>
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public int InventoryQuantity { get; set; }
        public int ReorderLevel { get; set; }
        public float UnitPrice { get; set; }
        public long ProductSubCategoryId { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IApplicationDbContext _context;
        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product() { 
                SKU = request.SKU,
                Name = request.Name,
                Description = request.description,
                InventoryQuantity = request.InventoryQuantity,
                ReorderLevel = request.ReorderLevel,
                UnitPrice = request.UnitPrice,
                ProductSubCategoryId =  request.ProductSubCategoryId
            };

            _context.Product.Add(product);

            await _context.SaveChangesAsync(cancellationToken);

            return product;
        }
    }
}
