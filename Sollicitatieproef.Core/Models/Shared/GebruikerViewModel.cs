using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sollicitatieproef.Core.Models.Shared;

public class GebruikerViewModel
{
    public int Id { get; set; }

    [DisplayName("Voornaam")]
    public string Voornaam { get; set; }


    [DisplayName("Naam")]
    public string Naam { get; set; }


    [DisplayName("E-mailadres")]
    public string Emailadres { get; set; }

    [DisplayName("Geboortedatum")]
    [DataType(DataType.Date)]
    public DateTime Geboortedatum { get; set; }


    [DisplayName("Serienummer")]
    public int Serienummer { get; set; }


    public IReadOnlyList<RechtViewModel> Rechten { get; set; }
}
