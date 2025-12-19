using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimoProgettoBlazor.Components.Classi.Entities
{
    [PrimaryKey("AbilitàIdAbilità", "PersonaggioId")]
    public class AbilitàPersonaggio
    {
        public Abilità Abilità { get; set; }
        public int AbilitàIdAbilità { get; set; }
        public Personaggio Personaggio { get; set; }
        public int PersonaggioId { get; set; }
        public int Punteggio { get; set; }
        [NotMapped]
        public bool Modifica { get; set; }
    }
}