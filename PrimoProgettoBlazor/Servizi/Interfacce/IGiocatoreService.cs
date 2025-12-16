using PrimoProgettoBlazor.Components.Classi.Entities;

namespace PrimoProgettoBlazor.Servizi.Interfacce
{
    public interface IGiocatoreService
    {
        public Task<List<Giocatore>> GetGiocatori();
        public Task<Giocatore> GetGiocatoreByName(string nome);
        public Task<string> SalvaGiocatore(Giocatore giocatore);
        public Task<string> EliminaGiocatore(Giocatore giocatore); 
    }
}
