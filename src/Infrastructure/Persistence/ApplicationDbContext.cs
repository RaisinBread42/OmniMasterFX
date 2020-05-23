using OmniMasterFX.Application.Common.Interfaces;
using OmniMasterFX.Domain.Common;
using OmniMasterFX.Domain.Entities;
using OmniMasterFX.Infrastructure.Identity;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace OmniMasterFX.Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;
        private IDbContextTransaction _currentTransaction;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService,
            IDateTime dateTime) : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        #region DbSets
        public DbSet<Color> Color { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<DeliveryProvider> DeliveryProvider { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderLineItem> OrderLineItem { get; set; }
        public DbSet<PaymentProvider> PaymentProvider { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductReview> ProductReview { get; set; }
        public DbSet<ProductSubCategory> ProductSubCategory { get; set; }
        public DbSet<ProductSize> ProductSize { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<VendorCategory> VendorCategory { get; set; }
        public DbSet<VendorSubCategory> VendorSubCategory { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
        #endregion

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                return;
            }

            _currentTransaction = await base.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted).ConfigureAwait(false);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);

                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // FK delete behaviors for categories
            builder.Entity<ProductSubCategory>()
                .HasOne(pc => pc.ProductCategory)
                .WithMany(psc => psc.ProductSubCategories)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<VendorSubCategory>()
                .HasOne(vc => vc.VendorCategory)
                .WithMany(vsc => vsc.VendorSubCategories)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }
    }
}
