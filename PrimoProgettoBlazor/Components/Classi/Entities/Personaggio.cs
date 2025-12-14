using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimoProgettoBlazor.Components.Classi.Entities
{
    public class Personaggio
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Iniziativa { get; set; }
        public string TiroColpire { get; set; }
        public string TiroDifesa { get; set; }
        public string ModifAttacco { get; set; }
        public int Salute { get; set; }
        public int Vigore { get; set; }
        public int Armatura { get; set; }
        public int LivelloMinaccia { get; set; }
        public Giocatore Giocatore { get; set; }
        public ICollection<AbilitàPersonaggio> Abilità { get; set; } = new List<AbilitàPersonaggio>(); 
        public ICollection<Attacco> Attacchi { get; set; } = new List<Attacco>();
        public Sessione Sessione { get; set; } = new Sessione();
    }
}
