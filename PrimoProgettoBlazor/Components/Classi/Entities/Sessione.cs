using System.ComponentModel.DataAnnotations;

namespace PrimoProgettoBlazor.Components.Classi.Entities
{
    public class Sessione
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Personaggio> Personaggi { get; set; } = new List<Personaggio>();
        public List<CategoriaKeyword> CategorieKeyword { get; set; } = new List<CategoriaKeyword>();

        public override string ToString()
        {
            return Nome; 
        }
    }
}
