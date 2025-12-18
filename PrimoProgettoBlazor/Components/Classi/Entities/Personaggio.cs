using System.ComponentModel.DataAnnotations;

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
        public int Salute { get; set; } = 40;
        public int Vigore { get; set; } = 40;
        public int Armatura { get; set; }
        public int LivelloMinaccia { get; set; }
        public Giocatore Giocatore { get; set; }
        public int GiocatoreId { get; set; }
        public ICollection<AbilitàPersonaggio> Abilità { get; set; } = new List<AbilitàPersonaggio>();
        public ICollection<Attacco> Attacchi { get; set; } = new List<Attacco>();
        public int SessioneId { get; set; }
        public Sessione Sessione { get; set; } = new Sessione();
    }
}
