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
                        if(personaggio.Sessione != null)
                        {
                            db.Entry(personaggio.Sessione).State = EntityState.Unchanged;
                        }

                        if(personaggio.Giocatore != null)
                        {
                            db.Entry(personaggio.Giocatore).State = EntityState.Unchanged;
                        }

                        foreach (AbilitàPersonaggio ap in personaggio.Abilità)
                        {
                            db.Entry(ap.Abilità).State = EntityState.Unchanged;
                            db.Entry(ap).State = EntityState.Deleted;
                            db.AbilitàPersonaggi.Remove(ap);
                        }
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
                        db.Entry(personaggio.Sessione).State = EntityState.Unchanged;
                        db.Entry(personaggio.Giocatore).State = EntityState.Unchanged;
                        if (personaggio.Id == 0)
                        {
                            db.Entry(personaggio).State = EntityState.Added;
                            db.Personaggi.Add(personaggio);
                        }
                        else
                        {
                            db.Entry(personaggio).State = EntityState.Modified;
                            db.Entry(personaggio.Giocatore).State = EntityState.Unchanged;
                            db.Personaggi.Update(personaggio);
                        }
                        await db.SaveChangesAsync();

                        foreach (AbilitàPersonaggio ap in personaggio.Abilità)
                        {
                            ap.PersonaggioId = personaggio.Id;
                            db.Entry(ap.Abilità).State = EntityState.Unchanged;
                            if (db.AbilitàPersonaggi.Any(x => x.PersonaggioId == ap.PersonaggioId && x.AbilitàIdAbilità == ap.AbilitàIdAbilità))
                            {
                                db.Entry(ap).State = EntityState.Modified;
                                db.AbilitàPersonaggi.Update(ap);
                            }
                            else
                            {
                                db.Entry(ap).State = EntityState.Added;
                                db.AbilitàPersonaggi.Add(ap);
                            }
                        }

                        foreach(Attacco attacco in personaggio.Attacchi)
                        {
                            db.Entry(attacco.Personaggio).State = EntityState.Unchanged;
                            attacco.PersonaggioId = personaggio.Id;

                            if (attacco.IdAttacco == 0)
                            {
                                db.Entry(attacco).State = EntityState.Added;
                                db.Attacchi.Add(attacco);
                            }
                            else
                            {
                                db.Entry(attacco).State = EntityState.Modified;
                                db.Attacchi.Update(attacco);
                            }

                            await db.SaveChangesAsync();                            

                            foreach(AttaccoPerk ap in attacco.AttacchiPerks)
                            {
                                db.Entry(ap).State = EntityState.Unchanged;
                                db.Entry(ap.Perk).State = EntityState.Unchanged;
                                ap.AttaccoId = attacco.IdAttacco; 
                                if(db.AttacchiPerks.Any(x => x.AttaccoId == ap.AttaccoId && x.PerkId == ap.PerkId))
                                {
                                    db.AttacchiPerks.Update(ap); 
                                }
                                else
                                {
                                    db.AttacchiPerks.Add(ap); 
                                }
                            }
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
