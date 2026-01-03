using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimoProgettoBlazor.Components.Classi.Entities
{
    public class Attacco
    {
        [Key]
        public int IdAttacco { get; set; }
        public string Nome { get; set; } = "";
        public int Roll { get; set; } = 0;
        public int Moltiplicatore { get; set; } = 0;
        public string Vigore { get; set; } = "";
        public string Affinità { get; set; } = "";
        public string Descrizione { get; set; } = "";
        public int PersonaggioId { get; set; } = 0;
        public Personaggio Personaggio { get; set; } = new Personaggio();
        [NotMapped]
        public bool InModifica { get; set; }
        public ICollection<AttaccoPerk> AttacchiPerks { get; set; } = new List<AttaccoPerk>();
    }
}
