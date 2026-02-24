using System.Net.Http.Json;
using System.Text.Json;
using ServiceRequestApp.Blazor.Models;

namespace ServiceRequestApp.Blazor.Services;

public class PokemonService : IPokemonService
{
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _jsonOptions;

    public PokemonService(HttpClient http)
    {
        _http = http;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    // GET - http://localhost:5000/api/pokemon
    public async Task<List<Pokemon>> GetAllAsync()
    {
        try
        {
            var response = await _http.GetFromJsonAsync<List<Pokemon>>("api/pokemon", _jsonOptions);
            return response ?? new List<Pokemon>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la récupération des pokémons : {ex.Message}");
            return new List<Pokemon>();
        }
    }

    // GET - http://localhost:5000/api/pokemon/:id
    public async Task<Pokemon?> GetByIdAsync(int id)
    {
        try
        {
            return await _http.GetFromJsonAsync<Pokemon>($"api/pokemon/{id}", _jsonOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors de la récupération du pokémon {id} : {ex.Message}");
            return null;
        }
    }

    // POST - http://localhost:5000/api/pokemon
    public async Task<bool> CreateAsync(Pokemon pokemon)
    {
        var response = await _http.PostAsJsonAsync("api/pokemon", pokemon);
        return response.IsSuccessStatusCode;
    }

    // PUT - http://localhost:5000/api/pokemon/:id
    public async Task<bool> UpdateAsync(int id, Pokemon pokemon)
    {
        var response = await _http.PutAsJsonAsync($"api/pokemon/{id}", pokemon);
        return response.IsSuccessStatusCode;
    }

    // DELETE - http://localhost:5000/api/pokemon/:id
    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/pokemon/{id}");
        return response.IsSuccessStatusCode;
    }
}