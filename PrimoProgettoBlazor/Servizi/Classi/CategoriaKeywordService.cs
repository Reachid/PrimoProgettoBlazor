using Microsoft.EntityFrameworkCore;
using PrimoProgettoBlazor.Components.Classi;
using PrimoProgettoBlazor.Components.Classi.Entities;
using PrimoProgettoBlazor.Servizi.Interfacce;

namespace PrimoProgettoBlazor.Servizi.Classi
{
    public class CategoriaKeywordService : ICategoriaKeywordService
    {
        IServiceScopeFactory factory;
        public CategoriaKeywordService(IServiceScopeFactory factory)
        {
            this.factory = factory;
        }

        public async Task<string> EliminaCategoriaKeyword(CategoriaKeyword categoria)
        {
            string errore = "";
            try
            {
                using (var scope = factory.CreateScope())
                {
                    using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        db.CategorieKeywords.Remove(categoria);
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

        public async Task<List<CategoriaKeyword>> GetCategorieKeyword(Giocatore giocatore, bool prendiKeywords = false)
        {
            List<CategoriaKeyword> categorie = new List<CategoriaKeyword>();
            using (var scope = factory.CreateScope())
            {
                using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                {
                    IQueryable<CategoriaKeyword> temp; 

                    if (giocatore.IsAdmin)
                    {
                        temp = db.CategorieKeywords; 
                    }
                    else
                    {
                        temp = db.CategorieKeywords.Where(x => !x.VisibileDaAdmin);
                    }

                    if (prendiKeywords)
                    {
                        if (giocatore.IsAdmin)
                        {
                            temp = temp.Include(x => x.Keywords).AsNoTracking();
                        }
                        else
                        {
                            temp = temp.Include(x => x.Keywords.Where(x => !x.VisibileSoloDaAdmin)).AsNoTracking();
                        }
                    }
                    categorie = await temp.ToListAsync();
                }
            }
            return categorie;
        }

        public async Task<string> SalvaCategoriaKeyword(CategoriaKeyword categoria)
        {
            string errore = "";
            try
            {
                using (var scope = factory.CreateScope())
                {
                    using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        if(categoria.Id == 0)
                        {
                            db.CategorieKeywords.Add(categoria); 
                        }
                        else
                        {
                            db.CategorieKeywords.Update(categoria);
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
