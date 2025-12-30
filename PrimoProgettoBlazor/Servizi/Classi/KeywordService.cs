using PrimoProgettoBlazor.Components.Classi;
using PrimoProgettoBlazor.Components.Classi.Entities;
using PrimoProgettoBlazor.Servizi.Interfacce;
using Microsoft.EntityFrameworkCore; 

namespace PrimoProgettoBlazor.Servizi.Classi
{
    public class KeywordService : IKeywordService
    {
        IServiceScopeFactory factory; 
        public KeywordService(IServiceScopeFactory factory)
        {
            this.factory = factory;
        }
        public async Task<string> EliminaKeyword(Keyword keyword)
        {
            string errore = "";
            try
            {
                using (var scope = factory.CreateScope())
                {
                    using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        if (keyword.CategoriaKeyword != null)
                        {
                            db.Entry(keyword.CategoriaKeyword).State = EntityState.Unchanged;
                        }
                        db.Keywords.Remove(keyword); 
                        await db.SaveChangesAsync();
                    }
                }
                return errore;
            }
            catch (Exception ex)
            {
                errore = ex.Message;
                return errore;
            }
        }

        public async Task<string> SalvaKeyword(Keyword keyword)
        {
            string errore = "";
            try
            {
                using (var scope = factory.CreateScope())
                {
                    using(BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        if(keyword.CategoriaKeyword != null)
                        {
                            db.Entry(keyword.CategoriaKeyword).State = EntityState.Unchanged;
                        }

                        if (keyword.Id == 0)
                        {
                            db.Keywords.Add(keyword); 
                        }
                        else
                        {
                            db.Keywords.Update(keyword); 
                        }
                        await db.SaveChangesAsync(); 
                    }
                }
                return errore; 
            }
            catch (Exception ex)
            {
                errore = ex.Message;
                return errore;
            }
        }
    }
}
