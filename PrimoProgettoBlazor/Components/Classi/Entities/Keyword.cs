using System.ComponentModel.DataAnnotations;

namespace PrimoProgettoBlazor.Components.Classi.Entities
{
    public class Keyword
    {
        [Key]
        public int Id { get; set; } = 0; 
        public string Titolo { get; set; } = "";
        public string Descrizione { get; set; } = "";
        public int CategoriaKeywordId { get; set; } = 0; 
        public bool VisibileSoloDaAdmin {  get; set; } = false;
        public CategoriaKeyword CategoriaKeyword { get; set; } = new CategoriaKeyword();
    }
}
