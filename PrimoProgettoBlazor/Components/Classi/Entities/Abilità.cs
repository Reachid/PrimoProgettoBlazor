namespace PrimoProgettoBlazor.Components.Classi.Entities
{
    public class Abilità : AbilitàPerk
    {
        public ICollection<AbilitàPersonaggio> Personaggi { get; set; }
    }
}
