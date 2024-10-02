using Microsoft.EntityFrameworkCore;
using Testiculo.Domain;

namespace Testiculo.Persistence.Contexto
{
    public class TesticuloContext : DbContext
    {
        public TesticuloContext(DbContextOptions<TesticuloContext> options) 
            : base(options)
        {

        }
        public DbSet<WeatherForecast> WeatherForecasts {get; set;}
        public DbSet<Evento> Eventos {get; set;}
        public DbSet<Lote> Lotes {get; set;}
        public DbSet<Palestrante> Palestrantes {get; set;}
        public DbSet<RedeSocial> RedesSociais {get; set;}   
        public DbSet<PalestranteEvento> PalestrantesEventos {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new {PE.EventoId, PE.PalestranteId});

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);                
        }
    }
}