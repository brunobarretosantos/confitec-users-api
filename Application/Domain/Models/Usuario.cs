using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementAPI.Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EscolaridadeId { get; set; }
         [ForeignKey("EscolaridadeId")]
        public Escolaridade? Escolaridade { get; set; }
        public int? HistoricoEscolarId { get; set; }
        [ForeignKey("HistoricoEscolarId")]
        public HistoricoEscolar? HistoricoEscolar { get; set; }
    }
}