using Microsoft.EntityFrameworkCore;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.Common;
using ProniaOnion.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyQueryFilters();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder); 
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
          var data =  ChangeTracker.Entries<BaseEntity>();
            foreach (var item in data)
            {
                switch (item.State)
                {
                 
                    case EntityState.Modified:
                        item.Entity.ModifiedAt = DateTime.Now;
                        break;
                    case EntityState.Added:
                        item.Entity.CreatedBy = "admin";
                        item.Entity.ModifiedAt = DateTime.Now;
                        item.Entity.CreatedAt = DateTime.Now;
                        break;
                  
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
