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

        public async Task<Giocatore?> GetGiocatoreByName(string nome)
        {
            Giocatore? giocatore = null;
            using (var scope = factory.CreateScope())
            {
                using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                {
                    giocatore = await db.Giocatori.Where(x => x.Nome.ToLower() == nome.ToLower()).Include(x => x.Personaggi).FirstOrDefaultAsync();
                }
            }
            return giocatore;
        }

        public async Task<Giocatore?> GetGiocatoreById(int idGiocatore)
        {
            Giocatore? giocatore = null;
            using (var scope = factory.CreateScope())
            {
                using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                {
                    giocatore = await db.Giocatori.Where(x => x.Id == idGiocatore).Include(x => x.Personaggi).FirstOrDefaultAsync();
                }
            }
            return giocatore;
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
