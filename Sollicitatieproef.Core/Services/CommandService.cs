using Microsoft.EntityFrameworkCore;
using Sollicitatieproef.Core.DataAccess;
using Sollicitatieproef.Core.DataAccess.Entities;
using Sollicitatieproef.Core.Models.Shared;

namespace Sollicitatieproef.Core.Services;

public class CommandService : ICommandService
{
    private readonly IDataContext _dataContext;

    public CommandService(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task CreateGebruikerAsync(GebruikerViewModel viewModel)
    {
        var serienummers = await _dataContext.Gebruikers
            .Select(g => g.Serienummer)
            .ToListAsync();

        var gebruiker = new Gebruiker
        {
            Voornaam = viewModel.Voornaam,
            Naam = viewModel.Naam,
            Emailadres = viewModel.Emailadres,
            Geboortedatum = viewModel.Geboortedatum!.Value,
            Serienummer = serienummers.DefaultIfEmpty(0).Max() + 1
        };

        _dataContext.Gebruikers.Add(gebruiker);
        await ((DbContext)_dataContext).SaveChangesAsync();

        var rechten = viewModel.Rechten.Where(r => r.IsToegekend);

        var gebruikerRechten = rechten.Select(r => new GebruikerRecht
        {
            GebruikerId = gebruiker.Id,
            RechtId = r.Id
        });

        _dataContext.GebruikerRechten.AddRange(gebruikerRechten);
        await ((DbContext)_dataContext).SaveChangesAsync();
    }

    public async Task DeleteGebruikerAsync(int id)
    {
        var gebruiker = _dataContext.Gebruikers.FirstOrDefault(g => g.Id == id);
        _dataContext.Gebruikers.Remove(gebruiker);

        await ((DbContext)_dataContext).SaveChangesAsync();
    }

    public async Task UpdateGebruikerAsync(GebruikerViewModel viewModel)
    {
        var gebruiker = await _dataContext.Gebruikers
            .Include(g => g.GebruikerRechten)
            .FirstOrDefaultAsync(g => g.Id == viewModel.Id);

        gebruiker.Voornaam = viewModel.Voornaam;
        gebruiker.Naam = viewModel.Naam;
        gebruiker.Geboortedatum = viewModel.Geboortedatum!.Value;
        gebruiker.Emailadres = viewModel.Emailadres;

        foreach (var recht in viewModel.Rechten)
        {
            if (recht.IsToegekend)
            {
                VoegRechtToe(gebruiker, recht);
            }

            else
            {
                NeemRechtAf(gebruiker, recht);
            }
        }

        await ((DbContext)_dataContext).SaveChangesAsync();
    }


    private static void VoegRechtToe(Gebruiker gebruiker, RechtViewModel toegekendRecht)
    {
        var gebruikerRecht = gebruiker.GebruikerRechten.FirstOrDefault(gr => gr.RechtId == toegekendRecht.Id);

        if (gebruikerRecht is null)
        {
            gebruikerRecht = new GebruikerRecht
            {
                GebruikerId = gebruiker.Id,
                RechtId = toegekendRecht.Id
            };

            gebruiker.GebruikerRechten.Add(gebruikerRecht);
        }
    }

    private static void NeemRechtAf(Gebruiker gebruiker, RechtViewModel afgenomenRecht)
    {
        var gebruikerRecht = gebruiker.GebruikerRechten.FirstOrDefault(gr => gr.RechtId == afgenomenRecht.Id);

        if (gebruikerRecht is not null)
        {
            gebruiker.GebruikerRechten.Remove(gebruikerRecht);
        }
    }
}
