using Sollicitatieproef.Core.Models.Shared;

namespace Sollicitatieproef.Core.Models.Gebruikers;

public class IndexViewModel
{
    public IReadOnlyList<GebruikerViewModel> Gebruikers { get; set; } = [];

}
