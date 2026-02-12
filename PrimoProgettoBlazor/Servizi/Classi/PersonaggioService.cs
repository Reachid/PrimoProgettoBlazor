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
                    using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        db.Attach(personaggio);
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
                    Personaggi = await db.Personaggi.Include(x => x.Sessione).ToListAsync();
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
                    Personaggio = await db.Personaggi.Include(ap => ap.Abilità)
                                                     .ThenInclude(x => x.Abilità)
                                                     .Include(at => at.Attacchi)
                                                     .ThenInclude(at => at.AttacchiPerks)
                                                     .ThenInclude(at => at.Perk)
                                                     .Include(AT => AT.Sessione)
                                                     .Include(at => at.Giocatore)
                                                     .Where(x => x.Id == idPersonaggio)
                                                     .AsNoTracking()
                                                     .FirstOrDefaultAsync();
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
                        db.Attach(personaggio);
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

        public async Task<string> ModificaAttacco(Attacco attacco)
        {
            string errore = "";
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        db.Attach(attacco);
                        db.Attacchi.Update(attacco);
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

        public async Task<string> EliminaAttacco(Attacco attacco)
        {
            string errore = "";
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        db.Attach(attacco);
                        db.Attacchi.Remove(attacco);
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
