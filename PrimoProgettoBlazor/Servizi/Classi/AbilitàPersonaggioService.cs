using Microsoft.EntityFrameworkCore;
using PrimoProgettoBlazor.Components.Classi;
using PrimoProgettoBlazor.Components.Classi.Entities;
using PrimoProgettoBlazor.Servizi.Interfacce;

namespace PrimoProgettoBlazor.Servizi.Classi
{
    public class AbilitàPersonaggioService : IAbilitàPersonaggioService
    {
        IServiceScopeFactory serviceScopeFactory; 
        public AbilitàPersonaggioService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory; 
        }

        public async Task<string> EliminaAbilitàPersonaggio(AbilitàPersonaggio abilitàPersonaggio)
        {
            string errore = "";
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        db.Entry(abilitàPersonaggio.Abilità).State = EntityState.Unchanged; 
                        db.AbilitàPersonaggi.Remove(abilitàPersonaggio); 
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

        public async Task<List<AbilitàPersonaggio>> GetAbilitàPersonaggio()
        {
            List<AbilitàPersonaggio> result = new List<AbilitàPersonaggio>();
            using (var scope = serviceScopeFactory.CreateScope())
            {
                using(BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                {
                    result = await db.AbilitàPersonaggi.ToListAsync(); 
                }
            }
            return result; 
        }

        public async Task<List<AbilitàPersonaggio>> GetAbilitàPersonaggioByPersonaggioId(int PersonaggioId)
        {
            List<AbilitàPersonaggio> result = new List<AbilitàPersonaggio>();
            using (var scope = serviceScopeFactory.CreateScope())
            {
                using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                {
                    result = await db.AbilitàPersonaggi.Where(x => x.PersonaggioId == PersonaggioId).ToListAsync();
                }
            }
            return result;
        }

        public async Task<string> SalvaAbilitàPersonaggio(AbilitàPersonaggio abilitàPersonaggio)
        {
            string errore = "";
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        AbilitàPersonaggio? copia = db.AbilitàPersonaggi.FirstOrDefault(x => x.PersonaggioId == abilitàPersonaggio.PersonaggioId && x.AbilitàIdAbilità == abilitàPersonaggio.AbilitàIdAbilità); 
                        if (copia == null)
                        {
                            db.AbilitàPersonaggi.Add(abilitàPersonaggio);
                        }
                        else
                        {
                            db.AbilitàPersonaggi.Update(abilitàPersonaggio);
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
