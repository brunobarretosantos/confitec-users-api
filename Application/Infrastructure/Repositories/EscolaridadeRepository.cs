using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Domain.Models;
using UserManagementAPI.Infrastructure.DbContext;

namespace UserManagementAPI.Application.Infrastructure.Repositories
{
    public class EscolaridadeRepository
    {
        private readonly ApplicationDbContext _context;

        public EscolaridadeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Escolaridade?> GetEscolaridadeByDescricaoAsync(string descricao)
        {
            return await _context.Escolaridades
                .Where(e => e.Descricao.Equals(descricao))
                .FirstOrDefaultAsync();
        }
    }
}