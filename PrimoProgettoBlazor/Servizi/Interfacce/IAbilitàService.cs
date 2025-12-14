using PrimoProgettoBlazor.Components.Classi.Entities;

namespace PrimoProgettoBlazor.Servizi.Interfacce
{
    public interface IAbilitàService
    {
        public Task<List<Abilità>> GetAbilità();
        public Task<string> SalvaAbilità(Abilità abilità);
        public Task<string> EliminaAbilità(Abilità abilità); 
    }
}
