using System;
namespace ServiceRequestApp.Application.DTOs;
using ServiceRequestApp.Domain.Enums;

public record PokemonDto(
    int Id,
    string Name,
    PokemonType Type,
    PokemonType? Type2,
    string? PreEvolution,
    string? Evolution,
    string? MegaEvolution,
    string Region,
    int Generation,
    string Image
);