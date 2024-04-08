namespace Sollicitatieproef.Core.DataAccess.Entities;

public class GebruikerRecht
{
    public int GebruikerId { get; set; }
    public int RechtId { get; set; }

    public virtual Gebruiker Gebruiker { get; set; } = default!;
    public virtual Recht Recht { get; set; } = default!;
}