using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.EntityFrameworkCore;
using PrimoProgettoBlazor.Components.Classi;
using PrimoProgettoBlazor.Components.Classi.Entities;
using PrimoProgettoBlazor.Components.Pages;
using PrimoProgettoBlazor.Servizi.Interfacce;

namespace PrimoProgettoBlazor.Servizi.Classi
{
    public class PerkService : IPerkService
    {
        IServiceScopeFactory factory; 
        public PerkService(IServiceScopeFactory factory)
        {
            this.factory = factory;
        }

        public async Task<string> EliminaPerk(Perk perk)
        {
            string errore = ""; 
            try
            {
                using (var scope = factory.CreateScope())
                {
                    using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        db.Perks.Remove(perk);
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

        public async Task<List<Perk>> GetPerks()
        {
            List<Perk> perks = new List<Perk>();
            using(var scope = factory.CreateScope())
            {
                using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                {
                    perks = await db.Perks.ToListAsync(); 
                }
            }
            return perks;
        }

        public async Task<string> SalvaPerk(Perk perk)
        {
            string errore = ""; 
            try
            {
                using (var scope = factory.CreateScope())
                {
                    using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        if(perk.Id == 0)
                        {
                            db.Perks.Add(perk);
                        }
                        else
                        {
                            db.Perks.Update(perk); 
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
