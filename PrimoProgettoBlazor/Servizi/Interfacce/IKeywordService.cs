using PrimoProgettoBlazor.Components.Classi.Entities;

namespace PrimoProgettoBlazor.Servizi.Interfacce
{
    public interface IKeywordService
    {
        public Task<string> SalvaKeyword(Keyword keyword);
        public Task<string> EliminaKeyword(Keyword keyword);
    }
}
