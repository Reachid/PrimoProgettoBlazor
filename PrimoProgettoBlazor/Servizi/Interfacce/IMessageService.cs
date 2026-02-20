namespace PrimoProgettoBlazor.Servizi.Interfacce
{
    public interface IMessageService
    {
        public Task<bool> ChiediConferma(string titolo, string messaggio);
        public void MostraMessaggioEsito(bool condizione, string messaggioPositivo, string messaggioNegativo);
    }
}
