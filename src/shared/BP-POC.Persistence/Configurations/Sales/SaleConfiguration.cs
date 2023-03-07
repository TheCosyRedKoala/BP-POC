using BP_POC.Domain.Sales;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BP_POC.Persistence.Configurations.Sales;

internal class SaleConfiguration : EntityConfiguration<Sale>
{
    public override void Configure(EntityTypeBuilder<Sale> builder)
    {
        base.Configure(builder);
    }
}
