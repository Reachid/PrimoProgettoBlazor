using PrimoProgettoBlazor.Components.Classi.Entities;

namespace PrimoProgettoBlazor.Servizi.Interfacce
{
    public interface ISessioneService
    {
        public Task<List<Sessione>> GetSessioni();
        public Task<string> SalvaSessione(Sessione sessione);
        public Task<string> EliminaSessione(Sessione sessione); 
    }
}
