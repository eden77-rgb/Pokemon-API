using ServiceRequestApp.Application.DTOs;
namespace ServiceRequestApp.Application.Interfaces;

public interface IPokemonService
{
    Task<List<PokemonDto>> GetAllAsync();
    Task<PokemonDto?> GetByIdAsync(int id);
    Task<(bool ok, string error,
          PokemonDto? created)>
        CreateAsync(CreatePokemonDto dto);
    Task<(bool ok, string error,
          PokemonDto? updated)>
        UpdateAsync(int id, UpdatePokemonDto dto);
    Task<bool> DeleteAsync(int id);
}

