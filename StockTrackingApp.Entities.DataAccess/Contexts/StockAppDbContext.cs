
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StockTrackingApp.Core.Entities.Base;
using StockTrackingApp.Core.Enums;
using StockTrackingApp.Entities.ApiEntities;
using StockTrackingApp.Entities.Configuration;
using StockTrackingApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApp.DataAccess.Contexts
{
    public class StockAppDbContext : IdentityDbContext
    {
        public const string ConnectionName = "StockTrackingApp";
        private readonly IHttpContextAccessor? _contextAccessor;

        public StockAppDbContext(DbContextOptions<StockAppDbContext> options, IHttpContextAccessor contextAccessor) : base(options)
        {
            _contextAccessor = contextAccessor;
        }

        public StockAppDbContext(DbContextOptions<StockAppDbContext> options) : base(options) { }
        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<ApiUser> ApiUsers { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Email> Emails { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductSupplier> Product_Suppliers { get; set; } = null!;
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; } = null!;
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = null!;
        public virtual DbSet<RegisterCode> RegisterCodes { get; set; } = null!;
        public virtual DbSet<SentMail> SentMails { get; set; } = null!;
        public virtual DbSet<Stock> Stocks { get; set; } = null!;
        public virtual DbSet<StockTransaction> StockTransactions { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<Warehouse> Warehouses { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(IEntityConfiguration).Assembly);
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            SetBaseProperties();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetBaseProperties();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void SetBaseProperties()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            string userId;

            //if (_contextAccessor.HttpContext == null)
            //{
            //    userId = "NotFound-User";
            //}
            //else
            //{
            //    userId = _contextAccessor?.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "NotFound-User";
            //}

                userId = _contextAccessor?.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "NotFound-User";
            foreach (var entry in entries)
            {
                SetIfAdded(entry, userId);
                SetIfModified(entry, userId);
                SetIfDeleted(entry, userId);
            }
        }

        private void SetIfAdded(EntityEntry<BaseEntity> entityEntry, string userId)
        {
            if (entityEntry.State != EntityState.Added)
            {
                return;
            }

            entityEntry.Entity.Status = Status.Active;
            entityEntry.Entity.CreatedDate = DateTime.Now;
            entityEntry.Entity.CreatedBy = userId;
            entityEntry.Entity.ModifiedDate = DateTime.Now;
            entityEntry.Entity.ModifiedBy = userId;
        }

        private void SetIfModified(EntityEntry<BaseEntity> entityEntry, string userId)
        {
            if (entityEntry.State == EntityState.Modified)
            {
                var originalStatus = (Status)entityEntry.OriginalValues[nameof(BaseEntity.Status)];
                var currentStatus = entityEntry.Entity.Status;

                if (originalStatus != currentStatus)
                {
                    entityEntry.Entity.Status = currentStatus;
                }
                else
                {
                    entityEntry.Entity.Status = originalStatus;
                }

                entityEntry.Entity.ModifiedDate = DateTime.Now;
                entityEntry.Entity.ModifiedBy = userId;
            }

        }

        private void SetIfDeleted(EntityEntry<BaseEntity> entityEntry, string userId)
        {
            if (entityEntry.State is not EntityState.Deleted)
            {
                return;
            }

            if (entityEntry.Entity is not AuditableEntity entity)
            {
                return;
            }

            entityEntry.State = EntityState.Modified;

            entity.Status = Status.Deleted;
            entity.DeletedBy = userId;
            entity.DeletedDate = DateTime.Now;
        }

    }
}
