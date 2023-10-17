using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Models;

namespace UserManagementAPI.Data
{
public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext() { }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }

        public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Escolaridade> Escolaridades { get; set; }
    public DbSet<HistoricoEscolar> HistoricosEscolares { get; set; }
}
}