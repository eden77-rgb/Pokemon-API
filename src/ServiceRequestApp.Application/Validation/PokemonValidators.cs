using ServiceRequestApp.Application.DTOs;

namespace ServiceRequestApp.Application.Validation;

public static class PokemonValidators 
{
    public static (bool ok, string error) Validate(CreatePokemonDto dto) 
    {
        if (string.IsNullOrWhiteSpace(dto.Name) || dto.Name.Length > 30) 
            return (false, "Le nom est obligatoire et doit faire moins de 30 caractères.");
            
        if (dto.Generation <= 0)
            return (false, "La génération doit être un nombre positif (ex: 1, 2, 3...).");

        if (string.IsNullOrWhiteSpace(dto.Region))
            return (false, "La région est obligatoire.");

        if (string.IsNullOrWhiteSpace(dto.Image))
            return (false, "L'URL ou le chemin de l'image est obligatoire.");

        return (true, "");
    }

    public static (bool ok, string error) Validate(UpdatePokemonDto dto) 
    {
        // On réutilise souvent la même logique pour la mise à jour
        if (string.IsNullOrWhiteSpace(dto.Name) || dto.Name.Length > 30)
            return (false, "Le nom est obligatoire et doit faire moins de 30 caractères.");

        if (dto.Generation <= 0)
            return (false, "La génération doit être un nombre positif.");

        return (true, "");
    }
}