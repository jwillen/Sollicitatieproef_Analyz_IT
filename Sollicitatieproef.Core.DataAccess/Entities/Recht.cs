namespace Sollicitatieproef.Core.DataAccess.Entities;

public class Recht
{
    public int Id { get; set; }
    public required string Omschrijving { get; set; }

    public virtual ICollection<GebruikerRecht> GebruikerRechten { get; set; } = new List<GebruikerRecht>();
}