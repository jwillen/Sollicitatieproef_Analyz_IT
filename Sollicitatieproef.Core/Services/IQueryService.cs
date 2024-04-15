using Sollicitatieproef.Core.DataAccess.Entities;

namespace Sollicitatieproef.Core.Services;

public interface IQueryService
{
    Task<IReadOnlyList<Gebruiker>> GetGebruikersAsync();

    Task<Gebruiker?> GetGebruikerByIdAsync(int id);

    Task<IReadOnlyList<Recht>> GetRechtenAsync();

    Task<bool> IsEmailadresUniek(int? gebruikerId, string emailadres);
}
