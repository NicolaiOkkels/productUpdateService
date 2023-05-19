using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using product_update_service.Entities;

namespace product_update_service.DataAccess
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
        public DbSet<Wine> Wines { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wine>(entity =>
        {
            entity.ToTable("wine_products");
            entity.Property(e => e.Id).HasColumnName("wine_id");
            entity.Property(e => e.AlcoholPercentage).HasColumnName("alcohol_percentage");
            entity.Property(e => e.CategoryId).HasColumnName("wine_category_id");
            entity.Property(e => e.Description).HasColumnName("wine_description");
            entity.Property(e => e.Name).HasColumnName("wine_name");
            entity.Property(e => e.Origin).HasColumnName("wine_origin");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Size).HasColumnName("bottle_size");
            entity.Property(e => e.Year).HasColumnName("production_year");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.ProductGuid).HasColumnName("product_uuid");
            entity.Property(e => e.ModifiedDate).HasColumnName("modified_date");
        });

            modelBuilder.Entity<Category>().ToTable("wine_categories");

            modelBuilder.Entity<Wine>()
                .HasOne(w => w.Category)
                .WithMany(c => c.Wines)
                .HasForeignKey(w => w.CategoryId);
        }
    }
}