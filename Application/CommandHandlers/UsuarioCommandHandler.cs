using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using UserManagementAPI.Application.Commands;
using UserManagementAPI.Application.Domain.Exceptions;
using UserManagementAPI.Application.Infrastructure.Repositories;
using UserManagementAPI.Domain.Models;

namespace UserManagementAPI.Application.CommandHandlers
{
    public class UsuarioCommandHandler
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly EscolaridadeRepository _escolaridadeRepository;

        public UsuarioCommandHandler(UsuarioRepository usuarioRepository, EscolaridadeRepository escolaridadeRepository)
        {
            _usuarioRepository = usuarioRepository;
            _escolaridadeRepository = escolaridadeRepository;
        }

        public async Task<int> Handle(AddUsuarioCommand command)
        {
            var escolaridade = await ObterEscolaridade(command.Escolaridade);            

            var usuario = command.ToModel();
            usuario.Escolaridade = escolaridade;
            usuario.EscolaridadeId = escolaridade.Id;

            int usuarioId = await _usuarioRepository.AddUsuarioAsync(usuario);
            return usuarioId;
        }

        public async Task Handle(UpdateUsuarioCommand command)
        {
            var escolaridade = await ObterEscolaridade(command.Escolaridade);

            var usuario = command.ToModel();
            usuario.Escolaridade = escolaridade;
            usuario.EscolaridadeId = escolaridade.Id;
            
            await _usuarioRepository.UpdateUsuarioAsync(usuario);
        }

        public async Task Handle(DeleteUsuarioCommand command)
        {
            await _usuarioRepository.DeleteUsuarioAsync(command.UsuarioId);
        }

        public async Task<Usuario?> GetUsuarioById(int id)
        {
            return await _usuarioRepository.GetUsuarioByIdAsync(id);
        }

        private async Task<Escolaridade> ObterEscolaridade(string? descricao)        
        {
            if (descricao.IsNullOrEmpty()) 
            {
                throw new RequiredFieldException(fieldName: "Escolaridadw", message: "Informe a Escolaridade");
            }

            var escolaridade = await _escolaridadeRepository.GetEscolaridadeByDescricaoAsync(descricao!);

            if (escolaridade == null)
            {
                throw new EscolaridadeInvalidaException(descricao!);
            }

            return escolaridade;
        }
    }
}
