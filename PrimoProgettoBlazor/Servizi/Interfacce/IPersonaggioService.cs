using PrimoProgettoBlazor.Components.Classi.Entities;

namespace PrimoProgettoBlazor.Servizi.Interfacce
{
    public interface IPersonaggioService
    {
        public Task<List<Personaggio>> GetPersonaggi();
        public Task<Personaggio?> GetPersonaggioById(int idPersonaggio);
        public Task<string> SalvaPersonaggio(Personaggio personaggio); 
        public Task<string> EliminaPersonaggio(Personaggio personaggio);
    }
}
