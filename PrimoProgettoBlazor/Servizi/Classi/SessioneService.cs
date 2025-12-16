using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PrimoProgettoBlazor.Components.Classi;
using PrimoProgettoBlazor.Components.Classi.Entities;
using PrimoProgettoBlazor.Servizi.Interfacce;

namespace PrimoProgettoBlazor.Servizi.Classi
{
    public class SessioneService : ISessioneService
    {
        IServiceScopeFactory factory; 
        public SessioneService(IServiceScopeFactory factory)
        {
            this.factory = factory;
        }

        public async Task<string> EliminaSessione(Sessione sessione)
        {
            try
            {
                using (var scope = factory.CreateScope())
                {
                    using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        db.Sessioni.Remove(sessione); 
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

        public async Task<List<Sessione>> GetSessioni()
        {
            List<Sessione> sessioni = new List<Sessione>(); 
            using (var scope = factory.CreateScope())
            {
                using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>()) 
                {
                    sessioni = await db.Sessioni.ToListAsync(); 
                }
            }
            return sessioni; 
        }

        public async Task<string> SalvaSessione(Sessione sessione)
        {
            try
            {
                using (var scope = factory.CreateScope())
                {
                    using (BancaDati db = scope.ServiceProvider.GetRequiredService<BancaDati>())
                    {
                        if (sessione.Id == 0)
                        {
                            db.Sessioni.Add(sessione);
                        }
                        else
                        {
                            db.Sessioni.Update(sessione);
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
