using System.ComponentModel.DataAnnotations;

namespace PrimoProgettoBlazor.Components.Classi.Entities
{
    public class Abilità
    {
        [Key]
        public int IdAbilità { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public ICollection<AbilitàPersonaggio> Personaggi { get; set; }
        public bool IsAbilità { get; set; } = true; 
    }
}
