using ServiceRequestApp.Application.DTOs;
using ServiceRequestApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ServiceRequestApp.Api.Endpoints;

public static class PokemonEndpoints
{
    public static void MapPokemonEndpoints(this WebApplication app) 
    {
        app.MapGet("/api/pokemon", async (IPokemonService service) => {
            var all = await service.GetAllAsync();
            return Results.Ok(all);
        });

        app.MapGet("/api/pokemon/{id:int}", async (int id,IPokemonService service) => {
            var item = await service.GetByIdAsync(id);
            return item == null ? Results.NotFound() : Results.Ok(item);
        });

        app.MapPost("/api/pokemon", async (CreatePokemonDto dto,IPokemonService service) => {
            var (ok, error, created) = await service.CreateAsync(dto);
            if (!ok) return Results.BadRequest(new { error });
            
            return Results.Created($"/api/pokemon/{created!.Id}", created);
        });

        app.MapPut("/api/pokemon/{id:int}", async (int id, UpdatePokemonDto dto,IPokemonService service) => {
            var (ok, error, updated) = await service.UpdateAsync(id, dto);
            if (!ok) { 
                if (error == "Pokémon non trouvé.") return Results.NotFound();
                return Results.BadRequest(new { error });
            }
            return Results.Ok(updated);
        });

        app.MapDelete("/api/pokemon/{id:int}", async (int id,IPokemonService service) => {
            var ok = await service.DeleteAsync(id);
            return ok ? Results.NoContent() : Results.NotFound();
        });
    }
}