namespace UserManagementAPI.Application.Domain.Exceptions
{
    public class UsuarioDuplicadoException : BadRequestException
    {
        public UsuarioDuplicadoException() : base("Usuário já cadastrado.")
        {

        }

        public UsuarioDuplicadoException(string message) : base(message)
        {

        }        
    }
}