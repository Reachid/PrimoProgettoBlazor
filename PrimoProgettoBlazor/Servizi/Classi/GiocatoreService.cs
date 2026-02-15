using Microsoft.EntityFrameworkCore;
using PrimoProgettoBlazor.Components.Classi;
using PrimoProgettoBlazor.Components.Classi.Entities;
using PrimoProgettoBlazor.Servizi.Interfacce;

namespace PrimoProgettoBlazor.Servizi.Classi
{
    public class GiocatoreService : IGiocatoreService
    {

        IServiceScopeFactory factory; 
        public GiocatoreService(IServiceScopeFactory factory)
        {
            this.factory = factory; 
        }
        
        public async Task<string> EliminaGiocatore(Giocatore giocatore)
        {
            try
            {
                using (var scope = factory.CreateScope())
                {
                    using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        db.Giocatori.Remove(giocatore);
                        await db.SaveChangesAsync(); 
                    }
                }
                return ""; 
            }
            catch (Exception ex)
            {
                return ex.Message; 
            }
        }

      
        public async Task<Giocatore?> GetGiocatore(object ricerca)
        {
            Giocatore? giocatore = null;
            using (var scope = factory.CreateScope())
            {
                using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                {
                    var query = db.Giocatori.AsQueryable(); 
                    if(ricerca is string nome)
                    {
                        query = query.Where(x => x.Nome.ToLower() == nome.ToLower()); 
                    }
                    else if(ricerca is int id)
                    {
                        query = query.Where(x => x.Id == id); 
                    }

                    Giocatore? provvisorio = query.FirstOrDefault(); 

                    if (provvisorio != null)
                    {
                        if (!provvisorio.IsAdmin)
                        {
                            query = query.Include(x => x.Personaggi.Where(y => !y.VisibileSoloAlMaster)).ThenInclude(x => x.Sessione); 
                        }
                        else
                        {
                            query = query.Include(x => x.Personaggi).ThenInclude(x => x.Sessione);
                        }
                    }
                    giocatore = await query.FirstOrDefaultAsync(); 

                    if (giocatore != null && giocatore.IsAdmin)
                    {
                        foreach (Personaggio p in db.Personaggi.Include(x => x.Giocatore).Include(x => x.Sessione).Where(x => x.GiocatoreId != giocatore.Id))
                        {
                            giocatore.Personaggi.Add(p);
                        }
                    }
                }
            }
            return giocatore;
        }
        public async Task<Giocatore?> GetGiocatoreByName(string nome)
        {
            return await GetGiocatore(nome);
        }

        public async Task<Giocatore?> GetGiocatoreById(int idGiocatore)
        {
            return await GetGiocatore(idGiocatore);
        }

        public async Task<List<Giocatore>> GetGiocatori()
        {
            List<Giocatore> giocatori = new List<Giocatore>();
            using (var scope = factory.CreateScope())
            {
                using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                {
                    giocatori = await db.Giocatori.ToListAsync();
                }
            }
            return giocatori;
        }

        public async Task<string> SalvaGiocatore(Giocatore giocatore)
        {
            try
            {
                using (var scope = factory.CreateScope())
                {
                    using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        if (giocatore.Id == 0)
                        {
                            db.Giocatori.Add(giocatore); 
                        }
                        else
                        {
                            db.Giocatori.Update(giocatore); 
                        }
                        await db.SaveChangesAsync();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
