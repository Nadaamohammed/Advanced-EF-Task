using Advanced_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Advanced_EF;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var product = modelBuilder.Entity<Product>();

        product.HasQueryFilter(p => !p.IsDeleted);

        product.Property(p => p.RowVersion)
               .IsRowVersion();

        product.HasIndex(p => p.Name);

        product.Property(p => p.Name)
               .HasMaxLength(200)
               .IsRequired();

        product.Property(p => p.Price)
               .HasPrecision(18, 2);

        product.HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);
    }
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
}
