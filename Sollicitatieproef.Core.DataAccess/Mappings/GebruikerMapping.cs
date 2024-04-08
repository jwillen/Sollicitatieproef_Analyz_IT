using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sollicitatieproef.Core.DataAccess.Entities;

namespace Sollicitatieproef.Core.DataAccess.Mappings;

public class GebruikerMapping : IEntityTypeConfiguration<Gebruiker>
{
    public void Configure(EntityTypeBuilder<Gebruiker> entity)
    {
        entity.ToTable("Gebruikers");

        entity.HasKey(e => e.Id);

        entity.Property(x => x.Id);
        entity.Property(x => x.Voornaam).HasMaxLength(50);
        entity.Property(x => x.Naam).HasMaxLength(50);
        entity.Property(x => x.Geboortedatum).HasMaxLength(50).HasColumnType("date");
        entity.Property(x => x.Emailadres).HasMaxLength(150);
        entity.Property(x => x.Serienummer);

        entity.HasIndex(x => x.Serienummer).IsUnique();
        entity.HasIndex(x => x.Emailadres).IsUnique();
    }
}