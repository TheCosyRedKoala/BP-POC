using BP_POC.Domain.Printers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BP_POC.Persistence.Configurations.Printers;

internal class PriceTierConfiguration : EntityConfiguration<PriceTier>
{
    public override void Configure(EntityTypeBuilder<PriceTier> builder)
    {
        base.Configure(builder);
    }
}
