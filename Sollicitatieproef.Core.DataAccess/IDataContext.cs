using Microsoft.EntityFrameworkCore;
using Sollicitatieproef.Core.DataAccess.Entities;

namespace Sollicitatieproef.Core.DataAccess;

public interface IDataContext
{
    DbSet<Gebruiker> Gebruikers { get; set; }
    DbSet<GebruikerRecht> GebruikerRechten { get; set; }
    DbSet<Recht> Rechten { get; set; }
}