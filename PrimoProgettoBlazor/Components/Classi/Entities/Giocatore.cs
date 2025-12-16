using System.ComponentModel.DataAnnotations;

namespace PrimoProgettoBlazor.Components.Classi.Entities
{
    public class Giocatore
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool IsAdmin { get; set; } = false; 
        public ICollection<Personaggio> Personaggi { get; set; } = new List<Personaggio>();
    }
}
