namespace UserManagementAPI.Domain.Models
{
    public class HistoricoEscolar
    {
        public int Id { get; set; }
        public required string Formato { get; set; }
        public required string Nome { get; set; }
    }
}