using PrimoProgettoBlazor.Servizi.Interfacce;
using Radzen;

namespace PrimoProgettoBlazor.Servizi.Classi
{
    public class MessageService : IMessageService
    {
        DialogService dialogService;
        NotificationService notification;

        public MessageService(DialogService _dialog, NotificationService _notification)
        {
            dialogService = _dialog;
            notification = _notification;
        }
        public async Task<bool> ChiediConferma(string titolo, string messaggio)
        {
            bool? result = await dialogService.Confirm(titolo, messaggio, new ConfirmOptions() { OkButtonText = "Sì", CancelButtonText = "No" });
            return result.HasValue && result.Value;
        }

        public bool MostraMessaggioEsito(bool condizione, string messaggioPositivo, string messaggioNegativo, bool mostraPositivo = true)
        {
            if (condizione && mostraPositivo)
            {
                notification.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = messaggioPositivo, Duration = 3000 });
                return true; 
            }
            else if(!condizione)
            {
                notification.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = messaggioNegativo, Duration = 5000 });
                return false; 
            }
            return true; 
        }
    }
}
