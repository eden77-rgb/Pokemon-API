using Microsoft.EntityFrameworkCore;
using ServiceRequestApp.Application.Interfaces;
using ServiceRequestApp.Domain.Entities;
using ServiceRequestApp.Infrastructure.Data;

namespace ServiceRequestApp.Infrastructure.Repositories;

public class PokemonRepository : IPokemonRepository
{
    private readonly AppDbContext _db;
    public PokemonRepository(AppDbContext db) => _db = db;

    public async Task<List<Pokemon>> GetAllAsync() 
        => await _db.Pokemons
                 .OrderBy(p => p.Id)
                 .ToListAsync();

    public async Task<Pokemon?> GetByIdAsync(int id)
        => await _db.Pokemons.FindAsync(id);

    public async Task<Pokemon> AddAsync(Pokemon pokemon)
    {
        _db.Pokemons.Add(pokemon);
        await _db.SaveChangesAsync();
        return pokemon;
    }
    
//////////////// Rest of the code in the next page ////////////////////////
///--- Rest of the code

    public async Task<Pokemon?> UpdateAsync(Pokemon request) 
    {
        var existing = await _db.Pokemons.FindAsync(request.Id);
        if (existing == null) return null;

        existing.Name = request.Name;
        existing.Type = request.Type;
        existing.Type2 = request.Type2;
        existing.SubEvolution = request.SubEvolution;
        existing.Evolution = request.Evolution;
        existing.MegaEvolution = request.MegaEvolution;
        existing.Region = request.Region;
        existing.Generation = request.Generation;
        existing.Image = request.Image;

        await _db.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _db.Pokemons.FindAsync(id);
        if (existing == null) return false;

        _db.Pokemons.Remove(existing);
        await _db.SaveChangesAsync();
        return true;
    }
}