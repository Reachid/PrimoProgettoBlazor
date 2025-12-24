using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimoProgettoBlazor.Components.Classi.Entities
{
    [PrimaryKey("AttaccoId", "PerkId")]
    public class AttaccoPerk
    {
        public int AttaccoId { get; set; }
        public Attacco Attacco { get; set; }
        public int PerkId { get; set; }
        public Perk Perk { get; set; }
        public int Punteggio { get; set; }

        [NotMapped]
        public bool Modifica { get; set; }
    }
}
