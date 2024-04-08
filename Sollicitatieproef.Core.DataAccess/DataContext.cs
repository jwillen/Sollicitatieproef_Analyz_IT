using Microsoft.EntityFrameworkCore;
using Sollicitatieproef.Core.DataAccess.Entities;

namespace Sollicitatieproef.Core.DataAccess;

public class DataContext : DbContext, IDataContext
{
    public DbSet<Gebruiker> Gebruikers { get; set; } = default!;
    public DbSet<GebruikerRecht> GebruikerRechten { get; set; } = default!;
    public DbSet<Recht> Rechten { get; set; } = default!;

    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Sollicitatieproef.Core;Integrated Security=true;TrustServerCertificate=True");
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        modelBuilder.UseCollation("Latin1_General_CI_AI");
    }
}