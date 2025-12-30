using PrimoProgettoBlazor.Components.Classi.Entities;

namespace PrimoProgettoBlazor.Servizi.Interfacce
{
    public interface IPerkService
    {
        public Task<List<Perk>> GetPerks(); 
        public Task<string> EliminaPerk(Perk perk); 
        public Task<string> SalvaPerk(Perk perk);
    }
}
