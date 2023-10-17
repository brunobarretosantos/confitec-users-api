namespace UserManagementAPI.Application.Commands
{
    public interface IUsuarioCommand
    {
        string Nome { get; set; }
        string Sobrenome { get; set; }
        string Email { get; set; }
        DateTime DataNascimento { get; set; }
        string? Escolaridade { get; set; }
    }
}