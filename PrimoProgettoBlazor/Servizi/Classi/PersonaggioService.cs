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
                        db.Entry(personaggio.Sessione).State = EntityState.Unchanged;
                        db.Entry(personaggio.Giocatore).State = EntityState.Unchanged;

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
                    Personaggio = await db.Personaggi.Include(ap => ap.Abilità)
                                                     .ThenInclude(x => x.Abilità)
                                                     .Include(at => at.Attacchi)
                                                     .Where(x => x.Id == idPersonaggio).AsNoTracking()
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
