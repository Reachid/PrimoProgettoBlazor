using System.ComponentModel.DataAnnotations;

namespace PrimoProgettoBlazor.Components.Classi.Entities
{
    public class CategoriaKeyword
    {
        [Key]
        public int Id { get; set; } = 0;
        public string Nome { get; set; } = "";
        public string Descrizione { get; set; } = ""; 
        public bool VisibileDaAdmin { get; set; } = false;
        public ICollection<Keyword> Keywords { get; set; } = new List<Keyword>();
    }
}
