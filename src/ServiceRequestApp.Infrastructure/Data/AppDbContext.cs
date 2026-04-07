using Microsoft.EntityFrameworkCore;
using ServiceRequestApp.Domain.Entities;
namespace ServiceRequestApp.Infrastructure.Data;

public class AppDbContext : DbContext {
 public AppDbContext(DbContextOptions<AppDbContext> options)
 : base(options) { }

 public DbSet<Pokemon> Pokemons => Set<Pokemon>();
 protected override void OnModelCreating(ModelBuilder modelBuilder) {
              base.OnModelCreating(modelBuilder);
                    modelBuilder.Entity<Pokemon>(entity => {
                        entity.ToTable("Pokemons");
                        entity.HasKey(e => e.Id);
                        entity.Property(e => e.Name)
                              .IsRequired()
                              .HasMaxLength(30);
                       entity.Property(e => e.Type)
                              .HasConversion<string>() 
                             .IsRequired();
                       entity.Property(e => e.Type2)
                             .HasConversion<string>() 
                             .IsRequired(false);
                       entity.Property(e => e.SubEvolution)
                             .HasMaxLength(30)
                             .IsRequired(false);
                       entity.Property(e => e.Evolution)
                             .HasMaxLength(30)
                             .IsRequired(false);
                       entity.Property(e => e.MegaEvolution)
                             .HasMaxLength(30)
                             .IsRequired(false);
                       entity.Property(e => e.Generation)
                             .IsRequired();
                       entity.Property(e => e.Region)
                             .IsRequired();
                       entity.Property(e => e.Image)
                             .IsRequired();
              });
    }
}
