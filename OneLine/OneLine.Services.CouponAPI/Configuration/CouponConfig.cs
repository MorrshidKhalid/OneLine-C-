using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneLine.Services.CouponAPI.Models;

namespace OneLine.Services.CouponAPI.Configuration
{
    public class CouponConfig
        : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.ToTable("Coupon", "oneline");
            builder.Property(c => c.Code)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(c => c.DiscountAmount)
                .IsRequired();

            builder.Property(c => c.ExpirationDate)
                .HasColumnType("DATE")
                .IsRequired();

            builder.HasData(
                new Coupon { CouponId = 1, Code = "K-INV25", DiscountAmount = 10, ExpirationDate = new DateOnly(2025, 3, 10) },
                new Coupon { CouponId = 2, Code = "Z-CH35", DiscountAmount = 10, ExpirationDate = new DateOnly(2025, 4, 4) },
                new Coupon { CouponId = 3, Code = "MAK-DES", DiscountAmount = 20, ExpirationDate = new DateOnly(2025, 3, 20) },
                new Coupon { CouponId = 4, Code = "DUP", DiscountAmount = 30, ExpirationDate = new DateOnly(2025, 4, 15) }
                );
        }
    }
}
