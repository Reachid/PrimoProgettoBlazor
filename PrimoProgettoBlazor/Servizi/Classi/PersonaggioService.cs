using Microsoft.EntityFrameworkCore;
using PrimoProgettoBlazor.Components.Classi;
using PrimoProgettoBlazor.Components.Classi.Entities;
using PrimoProgettoBlazor.Servizi.Interfacce;

namespace PrimoProgettoBlazor.Servizi.Classi
{
    public class PersonaggioService : IPersonaggioService
    {
        IServiceScopeFactory serviceScopeFactory; 
        public PersonaggioService(IServiceScopeFactory sf)
        {
            serviceScopeFactory = sf;
        }

        public async Task<string> EliminaPersonaggio(Personaggio personaggio)
        {
            string errore = "";
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using(BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        db.Personaggi.Remove(personaggio);
                        await db.SaveChangesAsync(); 
                    }
                }
            }
            catch (Exception ex)
            {
                errore = ex.Message; 
            }
            return errore; 
        }

        public async Task<List<Personaggio>> GetPersonaggi()
        {
            List<Personaggio> Personaggi = new List<Personaggio>(); 
            using (var scope = serviceScopeFactory.CreateScope())
            {
                using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>()) 
                {
                    Personaggi = await db.Personaggi.ToListAsync(); 
                }
            }
            return Personaggi; 
        }

        public async Task<Personaggio?> GetPersonaggioById(int idPersonaggio)
        {
            Personaggio? Personaggio = new Personaggio();
            using (var scope = serviceScopeFactory.CreateScope())
            {
                using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                {
                    Personaggio = await db.Personaggi.Where(x => x.Id == idPersonaggio).FirstOrDefaultAsync(); 
                }
            }
            return Personaggio;
        }

        public async Task<string> SalvaPersonaggio(Personaggio personaggio)
        {
            string errore = "";
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        if (personaggio.Id == 0)
                        {
                            db.Personaggi.Add(personaggio); 
                        }
                        else
                        {
                            db.Personaggi.Update(personaggio); 
                        }
                        await db.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                errore = ex.Message;
            }
            return errore;
        }
    }
}
