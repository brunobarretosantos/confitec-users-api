using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using UserManagementAPI.Application.Commands;
using UserManagementAPI.Application.Domain.Exceptions;
using UserManagementAPI.Application.Infrastructure.Repositories;
using UserManagementAPI.Application.Validators;
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

        public async Task<Usuario> Handle(AddUsuarioCommand command)
        {
            ValidarAtributos(command);

            var escolaridade = await ObterEscolaridade(command.Escolaridade);

            var usuario = command.ToModel();
            usuario.Escolaridade = escolaridade;
            usuario.EscolaridadeId = escolaridade.Id;

            var usuarioAdded = await _usuarioRepository.AddUsuarioAsync(usuario);
            return usuarioAdded;
        }

        public async Task Handle(UpdateUsuarioCommand command)
        {
            ValidarAtributos(command);
            
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
                throw new RequiredFieldException("Escolaridade");
            }

            var escolaridade = await _escolaridadeRepository.GetEscolaridadeByDescricaoAsync(descricao!);

            if (escolaridade == null)
            {
                throw new EscolaridadeInvalidaException(descricao!);
            }

            return escolaridade;
        }

        private void ValidarAtributos(IUsuarioCommand usuarioCommand) 
        {
            if (usuarioCommand.Nome.Trim().IsNullOrEmpty())
            {
                throw new RequiredFieldException("Nome");
            }

            if (usuarioCommand.Sobrenome.Trim().IsNullOrEmpty())
            {
                throw new RequiredFieldException("Sobrenome");
            }
            
            if (!EmailValidator.IsValid(usuarioCommand.Email)){
                throw new InvalidFieldException("E-Mail");
            }

            if (!DataNascimentoValidator.IsValid(usuarioCommand.DataNascimento)) {
                throw new InvalidFieldException("Data de Nascimento");
            }
        }
    }
}
