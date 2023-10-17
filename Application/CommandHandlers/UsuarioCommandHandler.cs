using System.Threading.Tasks;
using UserManagementAPI.Application.Commands;
using UserManagementAPI.Application.Infrastructure.Repositories;
using UserManagementAPI.Domain.Models;

namespace UserManagementAPI.Application.CommandHandlers
{
    public class UsuarioCommandHandler
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioCommandHandler(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<int> Handle(AddUsuarioCommand command)
        {
            int usuarioId = await _usuarioRepository.AddUsuarioAsync(command.ToModel());
            return usuarioId;
        }

        public async Task Handle(UpdateUsuarioCommand command)
        {
            await _usuarioRepository.UpdateUsuarioAsync(command.ToModel());
        }

        public async Task Handle(DeleteUsuarioCommand command)
        {
            await _usuarioRepository.DeleteUsuarioAsync(command.UsuarioId);
        }

        public async Task<Usuario?> GetUsuarioById(int id)
        {
            return await _usuarioRepository.GetUsuarioByIdAsync(id);
        }
    }
}
