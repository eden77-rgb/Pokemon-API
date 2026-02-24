using Microsoft.EntityFrameworkCore;
using ServiceRequestApp.Api.Endpoints;
using ServiceRequestApp.Application.Interfaces;
using ServiceRequestApp.Infrastructure.Data;
using ServiceRequestApp.Infrastructure.Repositories;
using ServiceRequestApp.Service.Services;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5078")
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
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();

builder.Services.AddScoped<IPokemonService, PokemonService>();


var app = builder.Build();


app.UseCors("BlazorPolicy");


app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapPokemonEndpoints();


app.Run();