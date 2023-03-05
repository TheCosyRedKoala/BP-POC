using BP_POC.Domain.Printers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BP_POC.Persistence.Configurations.Printers;

internal class PrinterConfiguration : EntityConfiguration<Printer>
{
    public override void Configure(EntityTypeBuilder<Printer> builder)
    {
        base.Configure(builder);

        builder.HasMany(p => p.PriceTiers)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
