using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace product_update_service.DataAccess
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Wine> Wine { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wine>()
                    .ToTable("wine_products")
                    .Property(w => w.Id)
                    .HasColumnName("wine_id");
            modelBuilder.Entity<Category>()
                    .ToTable("wine_categories")
                    .HasKey(c => c.Id);
        }
    }
}