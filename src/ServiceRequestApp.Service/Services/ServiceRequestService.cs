using ServiceRequestApp.Application.DTOs;
using ServiceRequestApp.Application.Interfaces;
using ServiceRequestApp.Application.Validation;
using ServiceRequestApp.Domain.Entities;
using ServiceRequestApp.Domain.Enums;

namespace ServiceRequestApp.Service.Services;

public class PokemonService : IPokemonService 
{
    private readonly IPokemonRepository _repo;

    public PokemonService(IPokemonRepository repo) => _repo = repo;

    public async Task<List<PokemonDto>> GetAllAsync()
    {
        var items = await _repo.GetAllAsync();
        return items.Select(ToDto).ToList();
    }

    public async Task<PokemonDto?> GetByIdAsync(int id)
    {
        var item = await _repo.GetByIdAsync(id);
        return item == null ? null : ToDto(item);
    }

    public async Task<(bool ok, string error, PokemonDto? created)> CreateAsync(CreatePokemonDto dto) 
    {
        var (ok, error) = PokemonValidators.Validate(dto);
        if (!ok) return (false, error, null);

        var entity = new Pokemon
        {
            Name = dto.Name.Trim(),
            Type = dto.Type,
            Type2 = dto.Type2,
            SubEvolution = dto.PreEvolution?.Trim(),
            Evolution = dto.Evolution?.Trim(),
            MegaEvolution = dto.MegaEvolution?.Trim(),
            Region = dto.Region.Trim(),
            Generation = dto.Generation,
            Image = dto.Image.Trim()
        };

        var created = await _repo.AddAsync(entity);
        return (true, "", ToDto(created));
    }

    public async Task<(bool ok, string error, PokemonDto? updated)> UpdateAsync(int id, UpdatePokemonDto dto) 
    {
        var (ok, error) = PokemonValidators.Validate(dto);
        if (!ok) return (false, error, null);

        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return (false, "Pokémon non trouvé.", null);

        // Mise à jour des propriétés
        existing.Name = dto.Name.Trim();
        existing.Type = dto.Type;
        existing.Type2 = dto.Type2;
        existing.SubEvolution = dto.PreEvolution?.Trim();
        existing.Evolution = dto.Evolution?.Trim();
        existing.MegaEvolution = dto.MegaEvolution?.Trim();
        existing.Region = dto.Region.Trim();
        existing.Generation = dto.Generation;
        existing.Image = dto.Image.Trim();

        var updated = await _repo.UpdateAsync(existing);
        return updated == null ? (false, "La mise à jour a échoué.", null) : (true, "", ToDto(updated));
    }

    public async Task<bool> DeleteAsync(int id) => await _repo.DeleteAsync(id);

    // ── Mapping Privé (Le traducteur Entity -> DTO) ────────────────────────
    private static PokemonDto ToDto(Pokemon e)
        => new PokemonDto(
            e.Id,
            e.Name,
            e.Type,
            e.Type2,
            e.SubEvolution,
            e.Evolution,
            e.MegaEvolution,
            e.Region,
            e.Generation,
            e.Image
        );
}