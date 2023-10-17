using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Domain.Models;
using UserManagementAPI.Application.Commands;
using UserManagementAPI.Application.CommandHandlers;
using UserManagementAPI.Application.Infrastructure.Repositories;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioCommandHandler _usuarioCommandHandler;
        private readonly UsuarioRepository _usuarioRepository;

        public UsuariosController(UsuarioCommandHandler usuarioCommandHandler, UsuarioRepository usuarioRepository)        
        {
            _usuarioCommandHandler = usuarioCommandHandler;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _usuarioRepository.GetUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(AddUsuarioCommand command)
        {
            var usuarioId = await _usuarioCommandHandler.Handle(command);

            return CreatedAtAction(nameof(GetUsuarios), new { id = usuarioId });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UpdateUsuarioCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _usuarioCommandHandler.Handle(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                var command = new DeleteUsuarioCommand { UsuarioId = id };
                await _usuarioCommandHandler.Handle(command);
                
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
