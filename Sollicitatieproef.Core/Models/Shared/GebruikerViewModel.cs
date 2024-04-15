using Microsoft.AspNetCore.Mvc;
using Sollicitatieproef.Core.Models.CustomValidators.GebruikerViewModelValidators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sollicitatieproef.Core.Models.Shared;

public class GebruikerViewModel
{
    public int Id { get; set; }

    [DisplayName("Voornaam")]
    [Required(ErrorMessage = "Gelieve een voornaam in te geven.")]
    public string Voornaam { get; set; }


    [DisplayName("Naam")]
    [Required(ErrorMessage = "Gelieve een naam in te geven.")]
    public string Naam { get; set; }


    [DisplayName("E-mailadres")]
    [Required(ErrorMessage = "Gelieve een e-mailadres in te geven.")]
    [EmailAddress(ErrorMessage = "Gelieve een geldig e-mailadres in te geven.")]
    [Remote(action: "EmailadresIsUniek", controller: "GebruikersValidatie", ErrorMessage = "Dit e-mailadres is reeds in gebruik. Gelieve een ander e-mailadres te kiezen.", AdditionalFields = nameof(Id))]
    public string Emailadres { get; set; }


    [DisplayName("Geboortedatum")]
    [Required(ErrorMessage = "Gelieve een geboortedatum in te geven.")]
    [DataType(DataType.Date)]
    [Remote(action: "GeboortedatumInHetVerleden", controller: "GebruikersValidatie", ErrorMessage = "De geboortedatum moet in het verleden liggen.")]
    public DateTime? Geboortedatum { get; set; }


    [DisplayName("Serienummer")]
    public int Serienummer { get; set; }

    [UserRights]
    public IReadOnlyList<RechtViewModel> Rechten { get; set; }
}
