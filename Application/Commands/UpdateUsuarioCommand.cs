using UserManagementAPI.Domain.Models;

namespace UserManagementAPI.Application.Commands
{
    public class UpdateUsuarioCommand : IUsuarioCommand
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Escolaridade { get; set; }        

        public Usuario ToModel()
    {
        return new Usuario
        {
            Id = this.Id,
            Nome = this.Nome,
            Sobrenome = this.Sobrenome,
            Email = this.Email,
            DataNascimento = this.DataNascimento,
        };
    }
                
    }
}