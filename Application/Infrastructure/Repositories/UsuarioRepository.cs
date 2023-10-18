using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Application.Domain.Exceptions;
using UserManagementAPI.Domain.Models;
using UserManagementAPI.Infrastructure.DbContext;

namespace UserManagementAPI.Application.Infrastructure.Repositories
{
    public class UsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            return await _context.Usuarios
                .Include(u => u.Escolaridade)
                .Include(u => u.HistoricoEscolar)
                .ToListAsync();
        }

        public async Task<Usuario?> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios
                .Include(u => u.Escolaridade)
                .Include(u => u.HistoricoEscolar)
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Usuario> AddUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            var usuarioToUpdate = await GetUsuarioByIdAsync(usuario.Id);

            if (usuarioToUpdate == null) {
                throw new UsuarioNaoExisteException();
            }

            usuarioToUpdate.Nome = usuario.Nome;
            usuarioToUpdate.Sobrenome = usuario.Sobrenome;
            usuarioToUpdate.DataNascimento = usuario.DataNascimento;
            usuarioToUpdate.Email = usuario.Email;
            usuarioToUpdate.Escolaridade = usuario.Escolaridade;

            _context.Attach(usuarioToUpdate);
            _context.Entry(usuarioToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUsuarioHistoricoEscolarAsync(Usuario usuario, HistoricoEscolar historicoEscolar)
        {
            var usuarioToUpdate = await GetUsuarioByIdAsync(usuario.Id);

            if (usuarioToUpdate == null) {
                throw new UsuarioNaoExisteException();
            }

            usuarioToUpdate.HistoricoEscolar = historicoEscolar;

            _context.Attach(usuarioToUpdate);
            _context.Entry(usuarioToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> IsEmailAlreadyExistsAsync(int comparingId, string email)
        {
            return await _context.Usuarios.AnyAsync(u => u.Email == email && u.Id != comparingId);
        }

        public async Task<bool> IsUserAlreadyExistsAsync(int comparingId, string nome, string sobrenome, DateTime dataNascimento)
        {
            return await _context.Usuarios.AnyAsync(u => 
                u.Nome == nome && 
                u.Sobrenome == sobrenome && 
                u.DataNascimento == dataNascimento && 
                u.Id != comparingId
            );
        }

    }
}