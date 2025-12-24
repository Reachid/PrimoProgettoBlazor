namespace PrimoProgettoBlazor.Components.Classi.Entities
{
    public class Perk : AbilitàPerk
    {
        public int Punteggio { get; set; }
        public ICollection<AttaccoPerk> AttacchiPerks { get; set; } = new List<AttaccoPerk>();
    }
}
