using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimoProgettoBlazor.Components.Classi.Entities
{
    [PrimaryKey("AbilitàId", "PersonaggioId")]
    public class AbilitàPersonaggio
    {
        public Abilità Abilità { get; set; } = new Abilità(); 
        public int AbilitàId { get; set; }
        public Personaggio Personaggio { get; set; }
        public int PersonaggioId { get; set; }
        public int Punteggio { get; set; }
        [NotMapped]
        public bool Modifica { get; set; }
    }
}