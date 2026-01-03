using PrimoProgettoBlazor.Components.Classi;
using PrimoProgettoBlazor.Components.Classi.Entities;
using PrimoProgettoBlazor.Servizi.Interfacce;

namespace PrimoProgettoBlazor.Servizi.Classi
{
    public class AttaccoPerkService : IAttaccoPerkService
    {
        IServiceScopeFactory factory; 
        public AttaccoPerkService(IServiceScopeFactory factory)
        {
            this.factory = factory;
        }
        public async Task<string> EliminaAttaccoPerk(AttaccoPerk quale)
        {
            try
            {
                using (var scope = factory.CreateScope())
                {
                    using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        db.Entry(quale.Perk).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                        db.Entry(quale.Attacco).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                        db.AttacchiPerks.Remove(quale);
                        await db.SaveChangesAsync();
                        return "";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message; 
            }
        }

        public async Task<string> SalvaAttaccoPerk(AttaccoPerk quale)
        {
            try
            {
                using (var scope = factory.CreateScope())
                {
                    using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        db.Entry(quale.Perk).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                        db.Entry(quale.Attacco).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged; 
                        if (db.AttacchiPerks.Any(x => x.AttaccoId == quale.AttaccoId && x.PerkId == quale.PerkId))
                        {
                            db.AttacchiPerks.Update(quale);
                        }
                        else
                        {
                            db.AttacchiPerks.Add(quale); 
                        }
                        await db.SaveChangesAsync();
                        return "";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
