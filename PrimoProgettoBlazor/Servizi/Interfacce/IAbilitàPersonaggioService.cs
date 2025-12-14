using PrimoProgettoBlazor.Components.Classi.Entities;

namespace PrimoProgettoBlazor.Servizi.Interfacce
{
    public interface IAbilitàPersonaggioService
    {
        public Task<List<AbilitàPersonaggio>> GetAbilitàPersonaggio();
        public Task<List<AbilitàPersonaggio>> GetAbilitàPersonaggioByPersonaggioId(int PersonaggioId);
        public Task<string> SalvaAbilitàPersonaggio(AbilitàPersonaggio abilitàPersonaggio);
        public Task<string> EliminaAbilitàPersonaggio(AbilitàPersonaggio abilitàPersonaggio); 
    }
}
