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
        public DbSet<Perk> Perks { get; set; }
        public DbSet<AttaccoPerk> AttacchiPerks { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<CategoriaKeyword> CategorieKeywords { get; set; }
        public BancaDati(DbContextOptions<BancaDati> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personaggio>().HasOne(x => x.Giocatore).WithMany(x => x.Personaggi).HasForeignKey(x => x.GiocatoreId);
            modelBuilder.Entity<Personaggio>().HasOne(x => x.Sessione).WithMany(x => x.Personaggi).HasForeignKey(x => x.SessioneId);
            modelBuilder.Entity<Personaggio>().HasMany(x => x.Abilità).WithOne(x => x.Personaggio).HasForeignKey(x => x.PersonaggioId);
            modelBuilder.Entity<Personaggio>().HasMany(x => x.Attacchi).WithOne(x => x.Personaggio).HasForeignKey(x => x.PersonaggioId);

            modelBuilder.Entity<Abilità>().HasMany(x => x.Personaggi).WithOne(x => x.Abilità).HasForeignKey(x => x.AbilitàIdAbilità);

            modelBuilder.Entity<Attacco>().HasMany(x => x.AttacchiPerks).WithOne(x => x.Attacco).HasForeignKey(x => x.AttaccoId);

            modelBuilder.Entity<Perk>().HasMany(x => x.AttacchiPerks).WithOne(x => x.Perk).HasForeignKey(x => x.PerkId);

            modelBuilder.Entity<Keyword>().HasOne(x => x.CategoriaKeyword).WithMany(x => x.Keywords).HasForeignKey(x => x.CategoriaKeywordId); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
