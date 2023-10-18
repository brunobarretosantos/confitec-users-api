namespace UserManagementAPI.Application.Domain.Exceptions
{
    public class HistoricoEscolarNaoExisteException : BadRequestException
    {
        public HistoricoEscolarNaoExisteException() : base("Histórico escolar não encontrado.")
        {

        }

        public HistoricoEscolarNaoExisteException(string message) : base(message)
        {

        }        
    }
}