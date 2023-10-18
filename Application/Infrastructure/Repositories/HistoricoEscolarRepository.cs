using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Application.Domain.Exceptions;
using UserManagementAPI.Domain.Models;
using UserManagementAPI.Infrastructure.DbContext;

namespace UserManagementAPI.Application.Infrastructure.Repositories
{
    public class HistoricoEscolarRepository
    {
         private readonly ApplicationDbContext _context;

        public HistoricoEscolarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HistoricoEscolar?> GetHistoricoEscolarByIdAsync(int id)
        {
            return await _context.HistoricosEscolares.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<HistoricoEscolar> AddHistoricoEscolarAsync(HistoricoEscolar historicoEscolar)
        {
            _context.HistoricosEscolares.Add(historicoEscolar);
            await _context.SaveChangesAsync();

            return historicoEscolar;
        }

        public async Task UpdateHistoricoEscolarAsync(HistoricoEscolar historicoEscolar)
        {
            var historicoEscolarToUpdate = await GetHistoricoEscolarByIdAsync(historicoEscolar.Id);

            if (historicoEscolarToUpdate == null) {
                throw new HistoricoEscolarNaoExisteException();
            }

            historicoEscolarToUpdate.Nome = historicoEscolar.Nome;

            _context.Attach(historicoEscolarToUpdate);
            _context.Entry(historicoEscolarToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}