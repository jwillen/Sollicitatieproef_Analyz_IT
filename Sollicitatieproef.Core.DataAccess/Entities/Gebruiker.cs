namespace Sollicitatieproef.Core.DataAccess.Entities;

public class Gebruiker
{
    public int Id { get; set; }
    public required string Voornaam { get; set; }
    public required string Naam { get; set; }
    public required DateTime Geboortedatum { get; set; }
    public required string Emailadres { get; set; }
    public required int Serienummer { get; set; }

    public virtual ICollection<GebruikerRecht> GebruikerRechten { get; set; } = new List<GebruikerRecht>();
}