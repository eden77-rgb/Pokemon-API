using ServiceRequestApp.Domain.Enums;
namespace ServiceRequestApp.Domain.Entities;
public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public PokemonType Type { get; set; }
    public PokemonType? Type2 { get; set; }
    public string? SubEvolution { get; set; }
    public string? Evolution { get; set; }
    public string? MegaEvolution { get; set; }
    public string Region { get; set; } = string.Empty;
    public int Generation { get; set; }
    public string Image { get; set; } = string.Empty;
}