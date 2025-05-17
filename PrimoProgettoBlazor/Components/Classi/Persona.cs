namespace PrimoProgettoBlazor.Components.Classi
{
    public class Persona
    {
        public static int Totale = 0; 
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Età {  get; set; }

        public Persona()
        {
            Totale += 1;
        }
    }
}
