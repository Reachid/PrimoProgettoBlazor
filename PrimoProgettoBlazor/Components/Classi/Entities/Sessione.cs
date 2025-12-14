namespace PrimoProgettoBlazor.Components.Classi.Entities
{
    public class Sessione
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Personaggio> Personaggi { get; set; }
    }
}
