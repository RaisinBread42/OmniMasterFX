using OmniMasterFX.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace OmniMasterFX.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Color> Color { get; set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<DeliveryProvider> DeliveryProvider { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<OrderLineItem> OrderLineItem { get; set; }
        DbSet<PaymentProvider> PaymentProvider { get; set; }
        DbSet<Picture> Picture { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<ProductCategory> ProductCategory { get; set; }
        DbSet<ProductReview> ProductReview { get; set; }
        DbSet<ProductSubCategory> ProductSubCategory { get; set; }
        DbSet<ProductSize> ProductSize { get; set; }
        DbSet<Vendor> Vendor { get; set; }
        DbSet<VendorCategory> VendorCategory { get; set; }
        DbSet<VendorSubCategory> VendorSubCategory { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        void RollbackTransaction();
    }
}
