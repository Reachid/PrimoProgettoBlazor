using System.ComponentModel.DataAnnotations;

namespace PrimoProgettoBlazor.Components.Classi.Entities
{
    public class Sessione
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Personaggio> Personaggi { get; set; }
    }
}
