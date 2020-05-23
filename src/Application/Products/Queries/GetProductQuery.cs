using OmniMasterFX.Application.Common.Interfaces;
using OmniMasterFX.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OmniMasterFX.Application.Products.Queries
{
    public class GetProductQuery : IRequest<ProductVM>
    {
        public long Id { get; set; }
    }

    public class GetProductQueryHandler: IRequestHandler<GetProductQuery, ProductVM>
    {
        private readonly IApplicationDbContext _context;
        public GetProductQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductVM> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            // use db context to fetch product with id 
            return await Task.Run(() => new ProductVM() { ProductDTO = new ProductDTO() { Id = 1 } });
        }
    }
}