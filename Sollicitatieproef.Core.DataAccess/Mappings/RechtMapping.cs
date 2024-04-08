using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sollicitatieproef.Core.DataAccess.Entities;

namespace Sollicitatieproef.Core.DataAccess.Mappings;

public class RechtMapping : IEntityTypeConfiguration<Recht>
{
    public void Configure(EntityTypeBuilder<Recht> entity)
    {
        entity.ToTable("Rechten");

        entity.HasKey(e => e.Id);

        entity.Property(x => x.Id);
        entity.Property(x => x.Omschrijving).HasMaxLength(50);
    }
}