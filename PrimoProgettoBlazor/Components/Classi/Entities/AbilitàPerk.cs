using System.ComponentModel.DataAnnotations;

namespace PrimoProgettoBlazor.Components.Classi.Entities
{
    public class AbilitàPerk
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public bool IsAbilità { get; set; } = true;
    }
}
