using Microsoft.AspNetCore.Mvc;
using Sollicitatieproef.Core.Models.Gebruikers;
using Sollicitatieproef.Core.Models.Shared;
using Sollicitatieproef.Core.Services;

namespace Sollicitatieproef.Core.Controllers;
public class GebruikersController : Controller
{
    private readonly ICommandService _commandService;
    private readonly IQueryService _queryService;

    public GebruikersController(
        ICommandService commandService,
        IQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var gebruikers = await _queryService.GetGebruikersAsync();

        var viewModel = new IndexViewModel
        {
            Gebruikers = gebruikers.Select(g => new GebruikerViewModel
            {
                Id = g.Id,
                Voornaam = g.Voornaam,
                Naam = g.Naam,
                Emailadres = g.Emailadres,
                Serienummer = g.Serienummer
            })
            .ToList()
        };

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Toevoegen()
    {
        var rechten = await _queryService.GetRechtenAsync();
        var viewModel = new GebruikerToevoegenViewModel
        {
            Gebruiker = new GebruikerViewModel
            {
                Rechten = rechten.Select(r => new RechtViewModel
                {
                    Id = r.Id,
                    Omschrijving = r.Omschrijving,
                    IsToegekend = false
                })
                .ToList()
            }
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Toevoegen(GebruikerToevoegenViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            await _commandService.CreateGebruikerAsync(viewModel.Gebruiker);
        }

        return RedirectToAction("Index");
    }


    [HttpGet]
    public async Task<IActionResult> Wijzigen(int id)
    {
        var gebruiker = await _queryService.GetGebruikerByIdAsync(id);
        var rechten = await _queryService.GetRechtenAsync();

        var viewModel = new GebruikerWijzigenViewModel
        {
            Gebruiker = new GebruikerViewModel
            {
                Id = gebruiker.Id,
                Voornaam = gebruiker.Voornaam,
                Naam = gebruiker.Naam,
                Emailadres = gebruiker.Emailadres,
                Geboortedatum = gebruiker.Geboortedatum,
                Serienummer = gebruiker.Serienummer,
                Rechten = rechten.Select(r => new RechtViewModel
                {
                    Id = r.Id,
                    Omschrijving = r.Omschrijving,
                    IsToegekend = gebruiker.GebruikerRechten.Select(gr => gr.RechtId).Contains(r.Id),

                }).ToList()
            }
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Wijzigen(GebruikerWijzigenViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            await _commandService.UpdateGebruikerAsync(viewModel.Gebruiker);
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Verwijderen(int id)
    {
        var gebruiker = await _queryService.GetGebruikerByIdAsync(id);
        var viewModel = new GebruikerVerwijderenViewModel
        {
            GebruikerId = gebruiker.Id,
            Voornaam = gebruiker.Voornaam,
            Naam = gebruiker.Naam
        };

        return PartialView("_Verwijderen", viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Verwijderen(GebruikerVerwijderenViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            await _commandService.DeleteGebruikerAsync(viewModel.GebruikerId);
        }

        return RedirectToAction("Index");
    }


}
