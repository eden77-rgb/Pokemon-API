namespace ServiceRequestApp.Blazor.Models;


public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? Type2 { get; set; }
    public string? PreEvolution { get; set; }
    public string? Evolution { get; set; }
    public string? MegaEvolution { get; set; }
    public string Region { get; set; } = string.Empty;
    public int Generation { get; set; }
    public string Image { get; set; } = string.Empty;
}