using Microsoft.EntityFrameworkCore;
using PrimoProgettoBlazor.Components.Classi;
using PrimoProgettoBlazor.Components.Classi.Entities;
using PrimoProgettoBlazor.Servizi.Interfacce;

namespace PrimoProgettoBlazor.Servizi.Classi
{
    public class AbilitàService : IAbilitàService
    {
        IServiceScopeFactory serviceScopeFactory; 
        public AbilitàService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<string> EliminaAbilità(Abilità abilità)
        {
            string errore = "";
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        db.Abilità.Remove(abilità);
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

        public async Task<List<Abilità>> GetAbilità()
        {
            List<Abilità> abilità = new List<Abilità>(); 
            using (var scope = serviceScopeFactory.CreateScope())
            {
                using(BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                {
                    abilità = await db.Abilità.ToListAsync(); 
                }
            }
            return abilità; 
        }

        public async Task<string> SalvaAbilità(Abilità abilità)
        {
            string errore = "";
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        if (abilità.Id == 0)
                        {
                            db.Abilità.Add(abilità); 
                        }
                        else
                        {
                            db.Abilità.Update(abilità); 
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
