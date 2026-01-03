using PrimoProgettoBlazor.Components.Classi.Entities;

namespace PrimoProgettoBlazor.Servizi.Interfacce
{
    public interface IAttaccoPerkService
    {
        public Task<string> SalvaAttaccoPerk(AttaccoPerk quale);
        public Task<string> EliminaAttaccoPerk(AttaccoPerk quale); 
    }
}
