using OmniMasterFX.Application.Common.Interfaces;
using OmniMasterFX.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OmniMasterFX.Application.PrimaryMenuItems.Queries
{
    public class GetPrimaryMenuItemsQuery : IRequest<MenuItem> { }

    //public class GetProductQueryHandler : IRequestHandler<GetPrimaryMenuItemsQuery, List<PrimaryMenu>>
    //{
    //    private readonly IApplicationDbContext _context;
    //    public GetProductQueryHandler(IApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<PrimaryMenu> Handle(GetPrimaryMenuItemsQuery request, CancellationToken cancellationToken)
    //    {
    //        // use db context to fetch product with id 
    //        var menu = 
    //        return await Task.Run(() => new ProductVM() { ProductDTO = new ProductDTO() { Id = 1 } });
    //    }
    //}
}
