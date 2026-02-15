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
                    Personaggi = await db.Personaggi.Include(x => x.Sessione).Include(x => x.Giocatore).AsNoTracking().ToListAsync();
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

        public void SetUnchanged(Personaggio personaggio, BancaDati db)
        {
            db.Entry(personaggio.Giocatore).State = EntityState.Unchanged;
            db.Entry(personaggio.Sessione).State = EntityState.Unchanged; 
            foreach(Attacco a in personaggio.Attacchi)
            {
                db.Entry(a).State = EntityState.Unchanged; 
            }
            foreach(AbilitàPersonaggio a in personaggio.Abilità)
            {
                db.Entry(a).State = EntityState.Unchanged; 
            }
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
                        SetUnchanged(personaggio, db); 
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
                        foreach (AttaccoPerk ap in attacco.AttacchiPerks)
                        {
                            db.Entry(ap).State = EntityState.Unchanged; 
                        }
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
                        foreach (AttaccoPerk ap in attacco.AttacchiPerks)
                        {
                            db.Entry(ap).State = EntityState.Unchanged;
                        }
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
