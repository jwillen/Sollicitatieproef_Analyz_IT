using Microsoft.AspNetCore.Mvc;
using Sollicitatieproef.Core.Services;
using System.Globalization;

namespace Sollicitatieproef.Core.Controllers;
public class GebruikersValidatieController : Controller
{
    private readonly IQueryService _queryService;

    public GebruikersValidatieController(IQueryService queryService)
    {
        _queryService = queryService;
    }

    [HttpGet]
    public async Task<JsonResult> EmailadresIsUniek()
    {
        var gebruikerIdAsString = Request.Query["Gebruiker.Id"];
        var emailadres = Request.Query["Gebruiker.Emailadres"];

        int? gebruikerId = string.IsNullOrEmpty(gebruikerIdAsString)
            ? null
            : int.Parse(gebruikerIdAsString);


        var isUniek = await _queryService.IsEmailadresUniek(gebruikerId, emailadres);
        return Json(isUniek);
    }

    [HttpGet]
    public async Task<JsonResult> GeboortedatumInHetVerleden()
    {
        var geboortedatum = DateTime.ParseExact(Request.Query["Gebruiker.Geboortedatum"], "yyyy-MM-dd", CultureInfo.InvariantCulture);
        return Json(geboortedatum < DateTime.Now);
    }
}
