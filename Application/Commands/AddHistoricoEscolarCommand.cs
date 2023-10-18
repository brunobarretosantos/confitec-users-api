namespace UserManagementAPI.Application.Commands
{
    public class AddHistoricoEscolarCommand
    {
        public int UsuarioId { get; set; }
        public required string Nome { get; set; }
        public required string Formato { get; set; }
    }
}