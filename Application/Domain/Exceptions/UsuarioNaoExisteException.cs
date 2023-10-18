namespace UserManagementAPI.Application.Domain.Exceptions
{
    public class UsuarioNaoExisteException : BadRequestException
    {
        public UsuarioNaoExisteException() : base("Usuário não encontrado.")
        {

        }

        public UsuarioNaoExisteException(string message) : base(message)
        {

        }        
    }
}