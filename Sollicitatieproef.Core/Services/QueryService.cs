using Microsoft.EntityFrameworkCore;
using Sollicitatieproef.Core.DataAccess;
using Sollicitatieproef.Core.DataAccess.Entities;

namespace Sollicitatieproef.Core.Services;

public class QueryService : IQueryService
{
    private readonly IDataContext _dataContext;

    public QueryService(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Gebruiker?> GetGebruikerByIdAsync(int id)
    {
        return await _dataContext.Gebruikers
            .AsNoTracking()
            .Include(g => g.GebruikerRechten)
            .FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<IReadOnlyList<Gebruiker>> GetGebruikersAsync()
    {
        return await _dataContext.Gebruikers.AsNoTracking().ToListAsync();
    }

    public async Task<IReadOnlyList<Recht>> GetRechtenAsync()
    {
        return await _dataContext.Rechten.AsNoTracking().ToListAsync();
    }
}
