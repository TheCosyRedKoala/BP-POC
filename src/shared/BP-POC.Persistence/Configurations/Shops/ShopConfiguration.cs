using BP_POC.Domain.Shops;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BP_POC.Persistence.Configurations.Shops;

internal class ShopConfiguration : EntityConfiguration<Shop>
{
    public override void Configure(EntityTypeBuilder<Shop> builder)
    {
        base.Configure(builder);

        builder.HasMany(s => s.Sales)
            .WithOne();

        builder.HasMany(s => s.Printers)
            .WithOne();

        builder.HasMany(s => s.Reports)
            .WithOne()
            .HasForeignKey(r => r.ShopId);

        builder.OwnsOne(s => s.Address, address =>
        {
            address.Property(a => a.AddressLine1)
                .HasColumnName(nameof(Address.AddressLine1));

            address.Property(a => a.AddressLine2)
                .HasColumnName(nameof(Address.AddressLine2));

            address.Property(a => a.City)
                .HasColumnName(nameof(Address.City));

            address.Property(a => a.PostalCode)
                .HasColumnName(nameof(Address.PostalCode));

            address.Property(a => a.Country)
                .HasColumnName(nameof(Address.Country));
        });

        builder.Ignore(s => s.TodaySales);
    }
}