using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sollicitatieproef.Core.DataAccess.Entities;

namespace Sollicitatieproef.Core.DataAccess.Mappings;

public class GebruikerRechtMapping : IEntityTypeConfiguration<GebruikerRecht>
{
    public void Configure(EntityTypeBuilder<GebruikerRecht> entity)
    {
        entity.ToTable("GebruikerRechten");

        entity.HasKey(e => new { e.GebruikerId, e.RechtId });

        entity.Property(x => x.GebruikerId);
        entity.Property(x => x.RechtId);

        entity.HasOne(x => x.Gebruiker).WithMany(x => x.GebruikerRechten).OnDelete(DeleteBehavior.Cascade);
        entity.HasOne(x => x.Recht).WithMany(x => x.GebruikerRechten).OnDelete(DeleteBehavior.Cascade);
    }
}