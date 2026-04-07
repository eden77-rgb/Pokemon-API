using ServiceRequestApp.Domain.Enums;

public record UpdatePokemonDto(
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