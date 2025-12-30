using PrimoProgettoBlazor.Components.Classi.Entities;

namespace PrimoProgettoBlazor.Servizi.Interfacce
{
    public interface ICategoriaKeywordService
    {
        public Task<List<CategoriaKeyword>> GetCategorieKeyword(Giocatore giocatore, bool prendiKeywords = false);
        public Task<string> SalvaCategoriaKeyword(CategoriaKeyword categoria);
        public Task<string> EliminaCategoriaKeyword(CategoriaKeyword categoria); 
    }
}
