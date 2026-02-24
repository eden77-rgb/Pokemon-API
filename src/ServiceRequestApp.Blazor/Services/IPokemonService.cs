using ServiceRequestApp.Blazor.Models;

namespace ServiceRequestApp.Blazor.Services;

public interface IPokemonService
{
    Task<List<Pokemon>> GetAllAsync();
    Task<Pokemon?> GetByIdAsync(int id);
    Task<bool> CreateAsync(Pokemon pokemon);
    Task<bool> UpdateAsync(int id, Pokemon pokemon);
    Task<bool> DeleteAsync(int id);
}