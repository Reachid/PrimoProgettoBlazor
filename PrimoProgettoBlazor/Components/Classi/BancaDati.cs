using Microsoft.EntityFrameworkCore;
using PrimoProgettoBlazor.Components.Classi.Entities;

namespace PrimoProgettoBlazor.Components.Classi
{
    public class BancaDati : DbContext
    {
        public DbSet<Giocatore> Giocatori { get; set; } 
        public DbSet<Personaggio> Personaggi { get; set; }
        public DbSet<Attacco> Attacchi { get; set; }
        public DbSet<Abilità> Abilità { get; set; }
        public DbSet<AbilitàPersonaggio> AbilitàPersonaggi { get; set; }
        public DbSet<Sessione> Sessioni { get; set; }   
        public BancaDati(DbContextOptions<BancaDati> options) : base(options)
        {

        }
    }
}
