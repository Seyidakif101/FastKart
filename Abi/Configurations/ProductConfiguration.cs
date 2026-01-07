using Abi.Models;
using Microsoft.EntityFrameworkCore;

namespace Abi.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.ToTable(x => x.HasCheckConstraint("CK_Product_Name", "LEN([Name])>3"));
            builder.Property(p => p.Description).IsRequired(false).HasMaxLength(50);
            builder.Property(p => p.Price).HasPrecision(18, 2).IsRequired();
            builder.ToTable(x => x.HasCheckConstraint("CK_Product_Price", "Price>=0"));
            builder.Property(p => p.ReytingCount).IsRequired();
            builder.Property(p => p.ReytingCount).IsRequired();
            builder.ToTable(x => x.HasCheckConstraint("CK_Product_ReytingCount", "ReytingCount >= 0 AND ReytingCount <= 5"));
        }
    }
}
