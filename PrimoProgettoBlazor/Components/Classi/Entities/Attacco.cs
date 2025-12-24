using System.ComponentModel.DataAnnotations;

namespace PrimoProgettoBlazor.Components.Classi.Entities
{
    public class Attacco
    {
        [Key]
        public int IdAttacco { get; set; }
        public string Nome { get; set; }
        public int Roll { get; set; }
        public int Moltiplicatore { get; set; }
        public string Vigore { get; set; }
        public Personaggio Personaggio { get; set; }
        public ICollection<AttaccoPerk> AttacchiPerks { get; set; } = new List<AttaccoPerk>();
    }
}
