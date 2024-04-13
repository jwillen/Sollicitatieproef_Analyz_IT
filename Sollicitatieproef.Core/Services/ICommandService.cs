using Sollicitatieproef.Core.Models.Shared;

namespace Sollicitatieproef.Core.Services;

public interface ICommandService
{
    Task CreateGebruikerAsync(GebruikerViewModel viewModel);

    Task DeleteGebruikerAsync(int id);

    Task UpdateGebruikerAsync(GebruikerViewModel viewModel);

}
