using Microsoft.EntityFrameworkCore;
using ServiceRequestApp.Api.Endpoints;
using ServiceRequestApp.Application.Interfaces;
using ServiceRequestApp.Infrastructure.Data;
using ServiceRequestApp.Infrastructure.Repositories;
using ServiceRequestApp.Service.Services;
using System.Text.Json.Serialization;
using ServiceRequestApp.Domain.Entities;
using ServiceRequestApp.Domain.Enums;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:8080")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorNumbersToAdd: null
        )
    )
);


builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();

builder.Services.AddScoped<IPokemonService, PokemonService>();


var app = builder.Build();


using (var scope = app.Services.CreateScope()) 
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    
    try 
    {
        context.Database.Migrate();
        
        if (!context.Pokemons.Any())
        {
            Console.WriteLine("--> La base est vide, début du seeding...");
            var csvPath = Path.Combine(AppContext.BaseDirectory, "pokemons.csv");
            Console.WriteLine($"--> Recherche du fichier : {csvPath}");
            
            if (File.Exists(csvPath))
            {
                Console.WriteLine("--> Fichier trouvé ! Lecture en cours...");

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    PrepareHeaderForMatch = args => args.Header.ToLower(),
                    Delimiter = ";"
                };

                using var reader = new StreamReader(csvPath, Encoding.UTF8);
                using var csv = new CsvReader(reader, config);
                
                var records = csv.GetRecords<dynamic>().ToList();
                
                foreach (var record in records)
                {
                    var pokemon = new Pokemon
                    {
                        // Id = int.Parse(record.n), 
                        Name = record.pokemon,
                        Type = Enum.Parse<PokemonType>(record.type, true),
                        Type2 = string.IsNullOrEmpty(record.type2) ? null : Enum.Parse<PokemonType>(record.type2, true),
                        SubEvolution = record.sub_evolution,
                        Evolution = record.evolution,
                        MegaEvolution = record.mega_evolution,
                        Region = record.region,
                        Generation = int.Parse(record.generation),
                        Image = record.sprite
                    };

                    context.Pokemons.Add(pokemon);
                }

                context.SaveChanges();
            }

            else 
            {
                Console.WriteLine("--> ERREUR : Fichier CSV introuvable à cet emplacement.");
            }
        }

        else 
        {
            Console.WriteLine("--> La base contient déjà des données, seeding annulé.");
        }
    }

    catch (Exception ex)
    {
        Console.WriteLine($"--> Erreur lors de l'initialisation de la base : {ex.Message}");
    }
}

app.UseCors("BlazorPolicy");

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapPokemonEndpoints();

app.Run();
